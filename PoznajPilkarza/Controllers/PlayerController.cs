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

            var result = Mapper.Map<IEnumerable<PlayerNameSurnameDto>>(playersEntities);
            GC.Collect();
            return Ok(result);
        }
    }
}