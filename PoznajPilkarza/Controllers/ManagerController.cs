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
    [Route("api/managers")]
    public class ManagerController : Controller
    {
        private IMangerRepository _mangerRepository;

        public ManagerController(IMangerRepository mangerRepository)
        {
            _mangerRepository = mangerRepository;
        }

        
        [HttpGet()]
        public IActionResult GetManagers()
        {
            var nationalityEntities = _mangerRepository.GetManagers();
            var result = Mapper.Map<IEnumerable<ManagerDto>>(nationalityEntities);

            return Ok(result);
        }

        [HttpGet("country/{country}")]
        public IActionResult GetManagersFromCountry(string country)
        {
            var managersEntities = _mangerRepository.GetManagersFromCountry(country);

            var result = Mapper.Map<IEnumerable<ManagerDto>>(managersEntities);
            GC.Collect();
            return Ok(result);
        }
        [HttpGet("league/{league}")]
        public IActionResult GetPlayersFromLeague(string league)
        {
            var managersEntities = _mangerRepository.GetManagersFromLeague(league);
            var result = Mapper.Map<IEnumerable<ManagerDto>>(managersEntities);
            GC.Collect();
            return Ok(result);
        }

        [HttpGet("{country}/{league}")]
        public IActionResult GetPlayersFromCountryWithLeague(string country, string league)
        {
            var managersEntities = _mangerRepository.GetManagersFromCountryWithLeague(country, league);
            var result = Mapper.Map<IEnumerable<ManagerDto>>(managersEntities);
            GC.Collect();
            return Ok(result);
        }
    }
}