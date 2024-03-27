using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) {
            _context = context;  //_context is like pool
        }

        //the name of the method (GetAll) does not matter, can be named whatever
        [HttpGet]
        public IEnumerable<Baker> GetAll() {
            return _context.Bakers;
        }

    
        [HttpPost]
        public IActionResult Post(Baker bakerToAdd) {
            _context.Add(bakerToAdd);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new {id = bakerToAdd.id}, bakerToAdd);
        }
    }
}
