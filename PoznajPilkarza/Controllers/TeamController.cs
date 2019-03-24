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
    [Route("api/teams")]
    public class TeamController : Controller
    {
        private ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet()]
        public IActionResult GetTeam()
        {
            var entitiesTeams = _teamRepository.GetTeams();
            var result = Mapper.Map<IEnumerable<TeamDto>>(entitiesTeams);
            return Ok(result);
        }
        [HttpGet("league/{league}")]
        public IActionResult GetTeamInLeague(string league)
        {
            var entitiesTeams = _teamRepository.GetTeamsInLeague(league);
            var result = Mapper.Map<IEnumerable<TeamDto>>(entitiesTeams);
            return Ok(result);
        }

    }
}