using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWebApplication.Models;
using RestWebApplication.Models.Entities;

namespace RestWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class JokesController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                RestDatabaseContext db = new RestDatabaseContext();
                return Ok(db.Jokes);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                RestDatabaseContext db = new RestDatabaseContext();
                Joke findJoke = db.Jokes.First(item => item.Id == id);
                db.Jokes.Remove(findJoke);
                db.SaveChanges();

                return Ok(id);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody] Joke joke)
        {
            try
            {
                RestDatabaseContext db = new RestDatabaseContext();
                db.Add(joke);
                db.SaveChanges();
                return Ok(joke);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Joke joke)
        {
            try
            {
                RestDatabaseContext db = new RestDatabaseContext();
                Joke findJoke = db.Jokes.First(item => item.Id == id);
                findJoke.Rating = joke.Rating;
                findJoke.Text = joke.Text;
                db.SaveChanges();
                return Ok(findJoke);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
