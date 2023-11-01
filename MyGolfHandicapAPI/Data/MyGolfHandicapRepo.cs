using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Data
{
    public class MyGolfHandicapRepo : IMyGolfHandicapRepo
    {
        private MyGolfHandicapContext _dbcontex;

        public MyGolfHandicapRepo(MyGolfHandicapContext dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public void UpdateDBMigrations()
        {
            if (_dbcontex.Database.GetPendingMigrations().Any())
            {
                _dbcontex.Database.Migrate();
            }
        }

        public User AddUser(string userName, string password)
        {
            var user = new User();
            user.UserName = userName;
            user.Password = password;
            _dbcontex.Users.Add(user);
            _dbcontex.SaveChanges();
            _dbcontex.SaveChanges();

            return user;
        }

        //public decimal GetHandicapIndex(int userId)
        //{
        //    decimal index = 0.0M;
        //    var scoreCards = Get18HoleScoreDifferentials(userId);
        //    int count = scoreCards.Count;

        //    switch (count)
        //    {
        //        case 0:
        //            index = 0.0M;
        //            break;
        //        case 1:
        //            index = 0.0M;
        //            break;
        //        case 2:
        //            index = 0.0M;
        //            break;
        //        case 3:
        //            index = scoreCards.Min(sd => sd.ScoreDiff) - 2;
        //            break;
        //        case 4:
        //            index = scoreCards.Min(sd => sd.ScoreDiff) - 1;
        //            break;
        //        case 5:
        //            index = scoreCards.Min(sd => sd.ScoreDiff);
        //            break;
        //        case 6:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff) - 1;
        //            break;
        //        case 7:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 8:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 9:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 10:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 11:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 12:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 13:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 14:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 15:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(5).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 16:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(5).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 17:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(6).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 18:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(6).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 19:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(7).Average(sd => sd.ScoreDiff);
        //            break;
        //        case 20:
        //            index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(8).Average(sd => sd.ScoreDiff);
        //            break;
        //        default:
        //            index = scoreCards.OrderByDescending(sd => sd.Date).Take(20).OrderBy(sd => sd.ScoreDiff).Take(8).Average(sd => sd.ScoreDiff);
        //            break;
        //    }

        //    return index;
        //}

        //public List<ScoreDifferential> Get18HoleScoreDifferentials(int userId)
        //{
        //    List<ScoreDifferential> SD18 = new List<ScoreDifferential>();
        //    ScoreDifferential temp = null;
        //    var scoreCards = _dbcontex.ScoreCards.Where(s => s.UserId == userId).ToList();

        //    foreach (ScoreCard scoreCard in scoreCards)
        //    {
        //        if (scoreCard.RoundType == 2)
        //        {
        //            if (temp == null)
        //            {
        //                temp = new ScoreDifferential();
        //                temp.ScoreDiff = scoreCard.ScoreDiff;
        //            }
        //            else
        //            {
        //                temp.ScoreDiff += scoreCard.ScoreDiff;

        //                if (scoreCard.Date > temp.Date)
        //                    temp.Date = scoreCard.Date;
        //                SD18.Add(temp);
        //                temp = null;
        //            }
        //        }
        //        else
        //        {
        //            temp = new ScoreDifferential();
        //            temp.ScoreDiff = scoreCard.ScoreDiff;
        //            temp.Date = scoreCard.Date;
        //            SD18.Add(temp);
        //            temp = null;
        //        }
        //    }

        //    return SD18;
        //}

        public IEnumerable<ScoreCard> GetScoreCards(int userID)
        {
            var scorecards = _dbcontex.ScoreCards.Where(s => s.UserId == userID).OrderByDescending(s => s.Date).Include(h => h.HoleScores).ToList();
            return scorecards;
        }

        public IEnumerable<GolfCourse> GetGolfCourses()
        {
            var golfcourses = _dbcontex.GolfCourses.ToList();
            return golfcourses;
        }

        public GolfCourse GetGolfCourseById(int id)
        {
            GolfCourse course = _dbcontex.GolfCourses.Where(g => g.GolfCourseId == id).Include(g => g.Tees).ThenInclude(h => h.Holes).FirstOrDefault();
            return course;
        }

        public IEnumerable<Tee> GetTees(int golfCourseId)
        {
            var tees = _dbcontex.Tees.Where(t => t.GolfCourseId == golfCourseId).ToList();
            return tees;
        }

        public GolfCourse AddGolfCourse(string name)
        {
            GolfCourse course = new GolfCourse();
            course.Name = name;
            _dbcontex.GolfCourses.Add(course);
            _dbcontex.SaveChanges();
            return course;
        }

        public Tee AddTee(GolfCourse course, string colour, decimal courseRating18, int slopeRating18, decimal courseRatingF9, int slopeRatingF9, decimal courseRatingB9, int slopeRatingB9)
        {
            Tee tee = new Tee();
            tee.GolfCourseId = course.GolfCourseId;
            tee.TeeColour = colour;
            tee.CourseRating18 = courseRating18;
            tee.SlopeRating18 = slopeRating18;
            tee.CourseRatingFront9 = courseRatingF9;
            tee.SlopeRatingFront9 = slopeRatingF9;
            tee.CourseRatingBack9 = courseRatingB9;
            tee.SlopeRatingBack9 = slopeRatingB9;
            _dbcontex.Tees.Add(tee);
            _dbcontex.SaveChanges();
            return tee;
        }

        public HoleInfo AddHole(Tee tee, int holeNumber, int par, int strokeIndex, int yards)
        {
            HoleInfo hole = new HoleInfo();
            hole.TeeId = tee.TeeId;
            hole.HoleNumber = holeNumber;
            hole.Par = par;
            hole.StrokeIndex = strokeIndex;
            hole.Yards = yards;
            _dbcontex.Holes.Add(hole);
            _dbcontex.SaveChanges();
            return hole;
        }

        public int GetUserId(string username, string password)
        {
            int userID = 0;

            User user = _dbcontex.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                if (user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(password))
                {
                    userID = user.UserId;
                }
            }

            return userID;
        }

        public ScoreCard GetScoreCard(int scorecardid)
        {
            ScoreCard scoreCard = _dbcontex.ScoreCards.Where(s => s.ScoreCardId == scorecardid).Include(h => h.HoleScores).FirstOrDefault();
            return scoreCard;
        }

        public int AddScoreCard(User user, GolfCourse course, int teeId, int roundType, DateTime date, List<int> scores)
        {
            ScoreCard scoreCard = new ScoreCard();
            Tee tee = course.Tees.Where(t => t.TeeId == teeId).FirstOrDefault();
            List<HoleInfo> holesPlayed;
            int par = 0;
            int total = 0;
            int i = 0;

            scoreCard.UserId = user.UserId;
            scoreCard.GolfCourseId = course.GolfCourseId;
            scoreCard.CourseName = course.Name;
            scoreCard.TeeColour = tee.TeeColour;
            scoreCard.Date = date;
            scoreCard.RoundType = roundType;

            _dbcontex.ScoreCards.Add(scoreCard);
            _dbcontex.SaveChanges();

            switch (roundType)
            {
                case 1:
                    holesPlayed = tee.Holes.OrderBy(h => h.HoleNumber).ToList();
                    break;
                case 2:
                    holesPlayed = tee.Holes.Where(h => h.HoleNumber >= 1 && h.HoleNumber < 10).OrderBy(h => h.HoleNumber).ToList();
                    break;
                case 3:
                    holesPlayed = tee.Holes.Where(h => h.HoleNumber > 9 && h.HoleNumber <= 18).OrderBy(h => h.HoleNumber).ToList();
                    break;
                default:
                    holesPlayed = tee.Holes.ToList();
                    break;
            }

            foreach (HoleInfo holeInfo in holesPlayed)
            {
                HoleScore holeScore = new HoleScore();
                holeScore.ScoreCardId = scoreCard.ScoreCardId;
                holeScore.HoleNumber = holeInfo.HoleNumber;
                holeScore.HolePar = holeInfo.Par;
                holeScore.StrokeIndex = holeInfo.StrokeIndex;
                holeScore.Yards = holeInfo.Yards;
                holeScore.Score = scores[i];

                par += holeInfo.Par;
                total += scores[i];

                _dbcontex.HoleScores.Add(holeScore);
                _dbcontex.SaveChanges();
                i++;
            }

            scoreCard.Par = par;
            scoreCard.GrossScore = total;
            _dbcontex.SaveChanges();

            switch (roundType)
            {
                case 1:
                    scoreCard.CourseRating = tee.CourseRating18;
                    scoreCard.SlopeRating = tee.SlopeRating18;
                    scoreCard.ScoreDiff = (Convert.ToDecimal(total) - tee.CourseRating18) * (113.0M / tee.SlopeRating18);
                    break;
                case 2:
                    scoreCard.CourseRating = tee.CourseRatingFront9;
                    scoreCard.SlopeRating = tee.SlopeRatingFront9;
                    scoreCard.ScoreDiff = (Convert.ToDecimal(total) - tee.CourseRatingFront9) * (113.0M / tee.SlopeRatingFront9);
                    break;
                case 3:
                    scoreCard.CourseRating = tee.CourseRatingBack9;
                    scoreCard.SlopeRating = tee.SlopeRatingBack9;
                    scoreCard.ScoreDiff = (Convert.ToDecimal(total) - tee.CourseRatingBack9) * (113.0M / tee.SlopeRatingBack9);
                    break;
            }

            _dbcontex.SaveChanges();

            UpdateHandicapIndex(user.UserId, date);

            return 0;
        }

        public int UpdateScoreCard(User user, ScoreCard scoreCard, List<int> scores)
        {
            int total = 0;
            int i = 0;
            List<HoleScore> holesPlayed = scoreCard.HoleScores.OrderBy(h => h.HoleNumber).ToList();

            foreach (HoleScore hole in holesPlayed)
            {
                hole.Score = scores[i];
                total += scores[i];
                i++;
            }

            scoreCard.GrossScore = total;
            scoreCard.ScoreDiff = (Convert.ToDecimal(total) - scoreCard.CourseRating) * (113.0M / scoreCard.SlopeRating);
            _dbcontex.SaveChanges();

            UpdateHandicapIndex(user.UserId, scoreCard.Date);

            return 0;
        }

        public void UpdateHandicapIndex(int userId, DateTime date)
        {
            var scoreCards = _dbcontex.ScoreCards.Where(s => s.UserId == userId && s.Date >= date).OrderBy(s => s.Date).ToList();

            foreach(ScoreCard scoreCard in scoreCards)
            {
                scoreCard.HandicapIndex = GetHandicapIndex(userId, scoreCard.Date);

                _dbcontex.SaveChanges();
            }
        }

        public decimal GetHandicapIndex(int userId, DateTime date)
        {
            decimal index = 0.0M;
            var scoreCards = Get18HoleScoreDifferentials(userId, date);
            int count = scoreCards.Count;

            switch (count)
            {
                case 0:
                    index = 0.0M;
                    break;
                case 1:
                    index = 0.0M;
                    break;
                case 2:
                    index = 0.0M;
                    break;
                case 3:
                    index = scoreCards.Min(sd => sd.ScoreDiff) - 2;
                    break;
                case 4:
                    index = scoreCards.Min(sd => sd.ScoreDiff) - 1;
                    break;
                case 5:
                    index = scoreCards.Min(sd => sd.ScoreDiff);
                    break;
                case 6:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff) - 1;
                    break;
                case 7:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff);
                    break;
                case 8:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(2).Average(sd => sd.ScoreDiff);
                    break;
                case 9:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
                    break;
                case 10:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
                    break;
                case 11:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(3).Average(sd => sd.ScoreDiff);
                    break;
                case 12:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
                    break;
                case 13:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
                    break;
                case 14:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(4).Average(sd => sd.ScoreDiff);
                    break;
                case 15:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(5).Average(sd => sd.ScoreDiff);
                    break;
                case 16:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(5).Average(sd => sd.ScoreDiff);
                    break;
                case 17:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(6).Average(sd => sd.ScoreDiff);
                    break;
                case 18:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(6).Average(sd => sd.ScoreDiff);
                    break;
                case 19:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(7).Average(sd => sd.ScoreDiff);
                    break;
                case 20:
                    index = scoreCards.OrderBy(sd => sd.ScoreDiff).Take(8).Average(sd => sd.ScoreDiff);
                    break;
                default:
                    index = scoreCards.OrderByDescending(sd => sd.Date).Take(20).OrderBy(sd => sd.ScoreDiff).Take(8).Average(sd => sd.ScoreDiff);
                    break;
            }

            return index;
        }

        public List<ScoreDifferential> Get18HoleScoreDifferentials(int userId, DateTime date)
        {
            List<ScoreDifferential> SD18 = new List<ScoreDifferential>();
            ScoreDifferential temp = null;
            var scoreCards = _dbcontex.ScoreCards.Where(s => s.UserId == userId && s.Date <= date).ToList();

            foreach (ScoreCard scoreCard in scoreCards)
            {
                if (scoreCard.RoundType == 2)
                {
                    if (temp == null)
                    {
                        temp = new ScoreDifferential();
                        temp.ScoreDiff = scoreCard.ScoreDiff;
                    }
                    else
                    {
                        temp.ScoreDiff += scoreCard.ScoreDiff;

                        if (scoreCard.Date > temp.Date)
                            temp.Date = scoreCard.Date;
                        SD18.Add(temp);
                        temp = null;
                    }
                }
                else
                {
                    temp = new ScoreDifferential();
                    temp.ScoreDiff = scoreCard.ScoreDiff;
                    temp.Date = scoreCard.Date;
                    SD18.Add(temp);
                    temp = null;
                }
            }

            return SD18;
        }

        public int DeleteScoreCardById(int scoreCardId)
        {
            ScoreCard s = _dbcontex.ScoreCards.Where(s => s.ScoreCardId == scoreCardId).FirstOrDefault();

            if (s != null)
            {
                _dbcontex.Remove(s);
                _dbcontex.SaveChanges();
            }

            UpdateHandicapIndex(s.UserId, s.Date);

            return 0;
        }

        public int GetUserCount()
        {
            return _dbcontex.Users.Count();
        }

        public User GetUserById(int id)
        {
            return _dbcontex.Users.Where(u => u.UserId == id).FirstOrDefault();
        }
    }
}
