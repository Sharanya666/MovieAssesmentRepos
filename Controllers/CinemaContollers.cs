using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOVIE.Models;
using MOVIE.Controllers;


namespace MOVIE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaControllers : ControllerBase
    {
        private readonly CinemaDbcontext _cinemaDbContext;
        public CinemaControllers(CinemaDbcontext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        [HttpGet]
        public IEnumerable<Cinemadb> GetCinemadbs()
        {
            return _cinemaDbContext.cinemadb.ToList();//select * from tutorial
        }
        [HttpGet("CinemaById")]
        public Cinemadb CinemaById(int CinemaId)
        {
            return _cinemaDbContext.cinemadb.Find(CinemaId);
        }

        [HttpPost("InsertCinema")]
        public IActionResult InsertCinema([FromBody]Cinemadb cinemadb)
        {
            if (cinemadb.CinemaId.ToString() != "")
            {
                _cinemaDbContext.cinemadb.Add(cinemadb);
                _cinemaDbContext.SaveChanges();
                return Ok("Inserted successfully");                
            }
            else
                return BadRequest(); 
        }

        [HttpPut("UpdateCinema")]
        public IActionResult UpdateCinema([FromBody] Cinemadb cp)
        {
            if (cp.CinemaId.ToString() != "")
            {
                //update tutorial set name=tutorial.name , desc=tutorial.desc , fees=tutorial.fees , publish=tutorial.publish where id=tutorial.id
                _cinemaDbContext.Entry(cp).State = EntityState.Modified;
                _cinemaDbContext.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }

        //localhost:3433/Tutorial/DeleteTutorial?tutorialId=3
        [HttpDelete("DeleteCinema")]
        public IActionResult DeleteTutorial(int CinemaId)
        {
            //select * from tutorial where tutorialId=3
            var result = _cinemaDbContext.cinemadb.Find(CinemaId);
            _cinemaDbContext.cinemadb.Remove(result);
            _cinemaDbContext.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}


