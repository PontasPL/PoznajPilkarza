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
            services.AddScoped<ILeagueRepository,LeagueRepository>();
            services.AddScoped<IMangerRepository, ManagerRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
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
            services.AddDbContext<ManagerContext>(o =>
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
                    .ForMember(dest => dest.PositionName, op => op.MapFrom(src => src.Position.ShortCode))
                    .ForMember(dest => dest.TeamName, op => op.MapFrom(src => src.Team.Name));
                //.ForMember(dest => dest.nameLeague, op => op.MapFrom(src => src.Team.League.Name));
                cfg.CreateMap<Manager, ManagerDto>(MemberList.Destination);
                cfg.CreateMap<Player, PlayerNameSurnameDto>(MemberList.Destination);
                cfg.CreateMap<Nationality, NationalityNameDto>(MemberList.Destination);
                cfg.CreateMap<League, LeagueNameNationalityDto>(MemberList.Destination);
                cfg.CreateMap<Player, PlayerExtendedDto>(MemberList.Destination)
                    .ForMember(dest => dest.DateOfBirth, op => op.MapFrom(src => src.DateOfBirth.ToString("d")))
                    .ForMember(dest => dest.PositionName, op => op.MapFrom(src => src.Position.ShortCode))
                    .ForMember(dest => dest.LeagueName, op => op.MapFrom(src => src.Team.League.Name))
                    .ForMember(dest => dest.TeamName, op => op.MapFrom(src => src.Team.Name))
                    .ForMember(dest => dest.NationalLeagueName,
                        op => op.MapFrom(src => src.Team.League.Nationality.Name))
                    .ForMember(dest => dest.FlagNational,
                        op => op.MapFrom(src => src.Nationality.PngImage))
                    .ForMember(dest => dest.FlagNationalLeague,
                        op => op.MapFrom(src => src.Team.League.Nationality.PngImage));
                cfg.CreateMap<Match, MatchDto>(MemberList.Destination)
                    .ForMember(dest=>dest.MatchDay,op=>op.MapFrom(src=>src.MatchDay.ToString("MM/dd/yyyy")));
                    
                cfg.CreateMap<Match, MatchDetailsDto>(MemberList.Destination)
                    .ForMember(dest => dest.Attendance, op => op.MapFrom(src => src.MatchDetails.Attendance))
                    .ForMember(dest=>dest.HomeTeamShots, op=>op.MapFrom(src=>src.MatchDetails.HomeTeamShots))
                    .ForMember(dest => dest.AwayTeamShots, op => op.MapFrom(src => src.MatchDetails.AwayTeamShots))
                    .ForMember(dest => dest.HomeTeamShotsOnTarget, op => op.MapFrom(src => src.MatchDetails.HomeTeamShotsOnTarget))
                    .ForMember(dest => dest.AwayTeamShotsOnTarget, op => op.MapFrom(src => src.MatchDetails.AwayTeamShotsOnTarget))
                    .ForMember(dest => dest.HomeTeamWoodWork, op => op.MapFrom(src => src.MatchDetails.HomeTeamWoodWork))
                    .ForMember(dest => dest.AwayTeamWoodWork, op => op.MapFrom(src => src.MatchDetails.AwayTeamWoodWork))
                    .ForMember(dest => dest.HomeTeamCorners, op => op.MapFrom(src => src.MatchDetails.HomeTeamCorners))
                    .ForMember(dest => dest.AwayTeamCorners, op => op.MapFrom(src => src.MatchDetails.AwayTeamCorners))
                    .ForMember(dest => dest.HomeTeamFoulsCommitted, op => op.MapFrom(src => src.MatchDetails.HomeTeamFoulsCommitted))
                    .ForMember(dest => dest.AwayTeamFoulsCommitted, op => op.MapFrom(src => src.MatchDetails.AwayTeamFoulsCommitted))
                    .ForMember(dest => dest.HomeTeamOffsides, op => op.MapFrom(src => src.MatchDetails.HomeTeamOffsides))
                    .ForMember(dest => dest.AwayTeamOffsides, op => op.MapFrom(src => src.MatchDetails.AwayTeamOffsides))
                    .ForMember(dest => dest.HomeYellowCards, op => op.MapFrom(src => src.MatchDetails.HomeYellowCards))
                    .ForMember(dest => dest.AwayYellowCards, op => op.MapFrom(src => src.MatchDetails.AwayYellowCards))
                    .ForMember(dest => dest.HomeTeamRedCards, op => op.MapFrom(src => src.MatchDetails.HomeTeamRedCards))
                    .ForMember(dest => dest.AwayTeamRedCards, op => op.MapFrom(src => src.MatchDetails.AwayTeamRedCards));

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
