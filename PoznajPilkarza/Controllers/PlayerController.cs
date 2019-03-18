using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoznajPilkarza.Models;
using PoznajPilkarza.Services;

namespace PoznajPilkarza.Controllers
{
    [Route("api/players")]
    public class PlayerController : Controller
    {
        private IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        
        [HttpGet()]
        public IActionResult GetPlayers()
        {
            var playersEntities = _playerRepository.GetPlayers();

            var result = Mapper.Map<IEnumerable<PlayerDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }
        [HttpGet("names")]
        public IActionResult GetPlayersNames()
        {
            var playersEntities = _playerRepository.GetPlayersNames();

            var result = Mapper.Map<IEnumerable<PlayerNameSurnameDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }

        [HttpGet("country/{country}")]
        public IActionResult GetPlayerFromCountry(string country)
        {
            var playersEntities = _playerRepository.GetPlayersFromCountry(country);

            var result = Mapper.Map<IEnumerable<PlayerDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }
        [HttpGet("league/{league}")]
        public IActionResult GetPlayersFromLeague(string league)
        {
            var playersEntities = _playerRepository.GetPlayersFromLeague(league);
            var result = Mapper.Map<IEnumerable<PlayerDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }

        [HttpGet("{country}/{league}")]
        public IActionResult GetPlayersFromCountryWithLeague(string country, string league)
        {
            var playersEntities = _playerRepository.GetPlayersFromCountryWithLeague(country, league);
            var result = Mapper.Map<IEnumerable<PlayerDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }
    }
}