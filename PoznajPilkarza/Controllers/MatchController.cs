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
    [Route("api/matches")]
    public class MatchController : Controller
    {
        private IMatchRepository _repository;

        public MatchController(IMatchRepository repository)
        {
            _repository = repository;
        }
        [HttpGet()]
        public IActionResult GetMatches()
        {
            var entitiesMatches = _repository.GetMatches();
            var result = Mapper.Map<IEnumerable<MatchDto>>(entitiesMatches);
            return Ok(result);
        }
        [HttpGet("withDetails")]
        public IActionResult GetMatchesWithDetails()
        {
            var entitiesMatches = _repository.GetMatchWithDetails();
            var result = Mapper.Map<IEnumerable<MatchDetailsDto>>(entitiesMatches);
            return Ok(result);
        }
    }
}