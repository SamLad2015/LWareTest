using System;
using System.Linq;
using LWareTest.Interfaces;
using LWareTest.Models;
using LWareTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LWareTest.Controllers
{
    [Route("api/[controller]")]
    public class LwRoverController : Controller
    {
        private readonly ILwRoverService _roverService;

        public LwRoverController(ILwRoverService lwRoverService)
        {
            _roverService = lwRoverService;
        }
        
        [HttpGet]
        public PositionDetails GetCurrentPositionDetails()
        {
            return _roverService.GetPosition();
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] string[] commands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _roverService.UpdatePosition(String.Join(",", commands));

            return Ok();
        }
    }
}