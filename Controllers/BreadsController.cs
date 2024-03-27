using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context) {
            _context = context;
        }

        //GET /api/breads
        // `IEnumerable<Bread>` is C#'s fancy way 
        // of saying "a list of Baker objects"
        [HttpGet]
        public IEnumerable<Bread> GetBreads() 
        {
            return _context.Breads
            // Include the `bakedBy` property
            // which is a list of `Baker` objects
            // .NET will do a JOIN for us!
            .Include(bread => bread.bakedBy);
        
        }

        // GET /api/breads/:id
        // Returns the bread with the given id
        [HttpGet("{id}")]
        public ActionResult<Bread> GetById(int id) {
            Bread bread =  _context.Breads
                .SingleOrDefault(bread => bread.id == id);
        
            if(bread is null) {
                return NotFound();
            }

            return bread;
        }

        //UPDATE /api/breads/:id
        [HttpPut("{id}")]
        public Bread Update(int id, Bread breadToChange)
        {
            breadToChange.id = id;

            _context.Update(breadToChange);

            _context.SaveChanges();

            return breadToChange;
        }

        //DELETE /api/breads/:id
        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id) {
            Bread bread = _context.Breads.Find(id);
        // tell db we want this specific bread removed
            _context.Breads.Remove(bread);

            _context.SaveChanges();

            //204
            return NoContent();
        }
    }
}
