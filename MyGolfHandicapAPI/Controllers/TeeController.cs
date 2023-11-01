using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyGolfHandicapAPI.Data;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Controllers
{
    [Route("api/tees")]
    [ApiController]
    public class TeeController : Controller
    {
        private readonly IMyGolfHandicapRepo _repo;

        public TeeController(IMyGolfHandicapRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [BasicAuthorization]
        public ActionResult<IEnumerable<Tee>> GetTees()
        {
            return Ok(_repo.GetTees(1));
        }
    }
}
