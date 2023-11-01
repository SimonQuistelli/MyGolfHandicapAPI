using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGolfHandicapAPI.Data;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Controllers
{
    [Route("api/scorecard")]
    [ApiController]
    public class ScoreCardController : ControllerBase
    {
        private readonly IMyGolfHandicapRepo _repo;

        public ScoreCardController(IMyGolfHandicapRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{scorecardid}")]
        [BasicAuthorization]
        public ActionResult<ScoreCard> GetScoreCard(int scorecardid)
        {
            return Ok(_repo.GetScoreCard(scorecardid));
        }

        [HttpPost]
        [BasicAuthorization]
        public ActionResult<int> AddScoreCard(AddScoreCardForm sc)
        {
            User user = _repo.GetUserById(sc.user_id);
            GolfCourse course = _repo.GetGolfCourseById(sc.golf_course_id);
            List<int> scores = new List<int>();

            switch (sc.round_type)
            {
                case 1:
                    scores.Add(sc.hole_score_1);
                    scores.Add(sc.hole_score_2);
                    scores.Add(sc.hole_score_3);
                    scores.Add(sc.hole_score_4);
                    scores.Add(sc.hole_score_5);
                    scores.Add(sc.hole_score_6);
                    scores.Add(sc.hole_score_7);
                    scores.Add(sc.hole_score_8);
                    scores.Add(sc.hole_score_9);
                    scores.Add(sc.hole_score_10);
                    scores.Add(sc.hole_score_11);
                    scores.Add(sc.hole_score_12);
                    scores.Add(sc.hole_score_13);
                    scores.Add(sc.hole_score_14);
                    scores.Add(sc.hole_score_15);
                    scores.Add(sc.hole_score_16);
                    scores.Add(sc.hole_score_17);
                    scores.Add(sc.hole_score_18);
                    break;
                case 2:
                    scores.Add(sc.hole_score_1);
                    scores.Add(sc.hole_score_2);
                    scores.Add(sc.hole_score_3);
                    scores.Add(sc.hole_score_4);
                    scores.Add(sc.hole_score_5);
                    scores.Add(sc.hole_score_6);
                    scores.Add(sc.hole_score_7);
                    scores.Add(sc.hole_score_8);
                    scores.Add(sc.hole_score_9);
                    break;
                case 3:
                    scores.Add(sc.hole_score_10);
                    scores.Add(sc.hole_score_11);
                    scores.Add(sc.hole_score_12);
                    scores.Add(sc.hole_score_13);
                    scores.Add(sc.hole_score_14);
                    scores.Add(sc.hole_score_15);
                    scores.Add(sc.hole_score_16);
                    scores.Add(sc.hole_score_17);
                    scores.Add(sc.hole_score_18);
                    break;
            }

            _repo.AddScoreCard(user, course, sc.tee_id, sc.round_type, sc.date, scores);
            return Ok(1);
        }

        [HttpPut]
        [BasicAuthorization]
        public ActionResult<int> UpdateScoreCard(UpdateScoreCardForm sc)
        {
            User user = _repo.GetUserById(sc.user_id);
            ScoreCard scoreCard = _repo.GetScoreCard(sc.scorecard_id);
            List<int> scores = new List<int>();

            switch (scoreCard.RoundType)
            {
                case 1:
                    scores.Add(sc.hole_score_1);
                    scores.Add(sc.hole_score_2);
                    scores.Add(sc.hole_score_3);
                    scores.Add(sc.hole_score_4);
                    scores.Add(sc.hole_score_5);
                    scores.Add(sc.hole_score_6);
                    scores.Add(sc.hole_score_7);
                    scores.Add(sc.hole_score_8);
                    scores.Add(sc.hole_score_9);
                    scores.Add(sc.hole_score_10);
                    scores.Add(sc.hole_score_11);
                    scores.Add(sc.hole_score_12);
                    scores.Add(sc.hole_score_13);
                    scores.Add(sc.hole_score_14);
                    scores.Add(sc.hole_score_15);
                    scores.Add(sc.hole_score_16);
                    scores.Add(sc.hole_score_17);
                    scores.Add(sc.hole_score_18);
                    break;
                case 2:
                    scores.Add(sc.hole_score_1);
                    scores.Add(sc.hole_score_2);
                    scores.Add(sc.hole_score_3);
                    scores.Add(sc.hole_score_4);
                    scores.Add(sc.hole_score_5);
                    scores.Add(sc.hole_score_6);
                    scores.Add(sc.hole_score_7);
                    scores.Add(sc.hole_score_8);
                    scores.Add(sc.hole_score_9);
                    break;
                case 3:
                    scores.Add(sc.hole_score_10);
                    scores.Add(sc.hole_score_11);
                    scores.Add(sc.hole_score_12);
                    scores.Add(sc.hole_score_13);
                    scores.Add(sc.hole_score_14);
                    scores.Add(sc.hole_score_15);
                    scores.Add(sc.hole_score_16);
                    scores.Add(sc.hole_score_17);
                    scores.Add(sc.hole_score_18);
                    break;
            }

            _repo.UpdateScoreCard(user, scoreCard, scores);
            return Ok(1);
        }

        [HttpDelete("{id:int}")]
        [BasicAuthorization]
        public ActionResult<int> DeleteScoreCard(int id)
        {
            int scoreCardId = id;

            if (scoreCardId != 1)
            {
                _repo.DeleteScoreCardById(scoreCardId);
            }
            return Ok(1);
        }
    }
}
