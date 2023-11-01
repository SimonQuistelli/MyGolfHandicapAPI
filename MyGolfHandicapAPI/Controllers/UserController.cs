using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyGolfHandicapAPI.Data;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMyGolfHandicapRepo _repo;

        public UserController(IMyGolfHandicapRepo repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<int> GetUserId(UserForm user)
        {
            int userID = _repo.GetUserId(user.username, user.password);

            if (userID == 0)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(userID);
        }
    }
}
