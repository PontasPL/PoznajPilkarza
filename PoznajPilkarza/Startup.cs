using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PoznajPilkarza.Enitites;
using PoznajPilkarza.Entities.Contexts;
using PoznajPilkarza.Models;
using PoznajPilkarza.SeedDatabase;
using PoznajPilkarza.Services;

namespace PoznajPilkarza
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddDbContext<MainContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("myConnectionString"),op=>op.EnableRetryOnFailure()));
            services.AddDbContext<NationalityContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));
            services.AddDbContext<LeagueContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));
            services.AddDbContext<PlayerContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));
            services.AddDbContext<MatchContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,NationalityContext nationalityContext,PlayerContext leagueContext,MatchContext matchContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            nationalityContext.EnsureSeedDataForContext();
            leagueContext.EnsureSeedDataForContext();
            matchContext.EnsureSeedDataForContext();
            app.UseCors("MyPolicy");

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Player, PlayerDto>(MemberList.Destination)
                    .ForMember(dest => dest.NameTeam, op => op.MapFrom(src => src.Team.Name))
                    .ForMember(dest => dest.PositionName, op => op.MapFrom(src => src.Position.ShortCode))
                    .ForMember(dest => dest.nameLeague, op => op.MapFrom(src => src.Team.League.Name));
                   
                //.AfterMap(((player, dto) => Mapper.Map(player.Team.League.Name, dto.LeagueName)));
                //cfg.CreateMap<Player, TestPlayer>().ForSourceMember(x=>x.Description, opt=>opt.DoNotValidate());
                cfg.CreateMap<Player, PlayerNameSurnameDto>(MemberList.Destination)
                    .ForMember(dest => dest.Team, op => op.MapFrom(src => src.Team.Name));
                cfg.CreateMap<Nationality, NationalityNameDto>(MemberList.Destination);
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
