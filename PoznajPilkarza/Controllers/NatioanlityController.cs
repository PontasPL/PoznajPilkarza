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
    [Route("api/nationalities")]
    public class NatioanlityController : Controller
    {
        private INationalityRepository _nationalityRepository;

        public NatioanlityController(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }

        

        [HttpGet()]
        public IActionResult GetNationalities()
        {
            var nationalitiesEntities = _nationalityRepository.GetNationalities();

            var result = Mapper.Map<IEnumerable<NationalityNameDto>>(nationalitiesEntities);
            return Ok(result);
        }
        [HttpGet("players")]
        public IActionResult GetNationalitiesPlayers()
        {
            var nationalitiesEntities = _nationalityRepository.GetPlayersNationalities();

            var result = Mapper.Map<IEnumerable<NationalityNameDto>>(nationalitiesEntities);
            return Ok(result);
        }
    }
}