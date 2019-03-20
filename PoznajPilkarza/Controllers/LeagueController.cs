using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoznajPilkarza.Models;
using PoznajPilkarza.Services;

namespace PoznajPilkarza.Controllers
{
    [Route("api/leagues")]
    public class LeagueController : Controller
    {
        private ILeagueRepository _leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }
        [HttpGet()]
        public IActionResult GetLeagues()
        {
            var repository = _leagueRepository.GetLeagues();
            var result = Mapper.Map<IEnumerable<LeagueNameNationalityDto>>(repository);
            return Ok(result);
        }
        [HttpGet("matches")]
        public IActionResult GetLeaguesMatches()
        {
            var repository = _leagueRepository.GetLeaguesMatches();
            var result = Mapper.Map<IEnumerable<LeagueNameNationalityDto>>(repository);
            return Ok(result);
        }
    }
}