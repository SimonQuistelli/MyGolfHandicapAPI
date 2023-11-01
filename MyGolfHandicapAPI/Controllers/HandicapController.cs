using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGolfHandicapAPI.Data;
using System.Security.Claims;

namespace MyGolfHandicapAPI.Controllers
{
    [Route("api/handicapindex")]
    [ApiController]
    public class HandicapController : ControllerBase
    {
        private readonly IMyGolfHandicapRepo _repo;

        public HandicapController(IMyGolfHandicapRepo repo)
        {
            _repo = repo;
        }

        //[HttpGet]
        [BasicAuthorization]
        [HttpGet("{userid}")]
        public ActionResult<int> GetHandicapIndex(int userId)
        {
            //var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var username = User.FindFirstValue(ClaimTypes.Name);
            //string name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(String.Format("{0:0.0}", _repo.GetHandicapIndex(userId, DateTime.Now)));
        }
    }
}
