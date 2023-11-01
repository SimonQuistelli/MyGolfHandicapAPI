using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyGolfHandicapAPI.Data;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Controllers
{
    [Route("api/golfcourses")]
    [ApiController]
    public class GolfCourseController : Controller
    {
        private readonly IMyGolfHandicapRepo _repo;

        public GolfCourseController(IMyGolfHandicapRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [BasicAuthorization]
        public ActionResult<IEnumerable<GolfCourse>> GetGolfCourses()
        {
            return Ok(_repo.GetGolfCourses());
        }
        [HttpGet("{id}")]
        [BasicAuthorization]
        public ActionResult<GolfCourse> GetGolfCourses(int id)
        {
            return Ok(_repo.GetGolfCourseById(id));
        }
    }
}
