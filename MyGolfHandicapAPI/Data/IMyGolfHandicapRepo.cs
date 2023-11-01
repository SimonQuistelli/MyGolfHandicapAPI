using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Data
{
    public interface IMyGolfHandicapRepo
    {
        void UpdateDBMigrations();
        User AddUser(string email, string password);

        decimal GetHandicapIndex(int userID, DateTime date);

        int GetUserId(string email, string password);

        IEnumerable<ScoreCard> GetScoreCards(int userID);

        IEnumerable<GolfCourse> GetGolfCourses();

        GolfCourse GetGolfCourseById(int id);
        IEnumerable<Tee> GetTees(int golfCourseId);
        GolfCourse AddGolfCourse(string name);

        Tee AddTee(GolfCourse course, string colour, decimal courseRating18, int slopeRating18, decimal courseRatingF9, int slopeRatingF9, decimal courseRatingB9, int slopeRatingB9);

        HoleInfo AddHole(Tee tee, int holeNumber, int par, int strokeIndex, int yards);

        ScoreCard GetScoreCard(int scorecardid);

        int AddScoreCard(User user, GolfCourse course, int teeId, int roundType, DateTime date, List<int> scores);

        int UpdateScoreCard(User user, ScoreCard scoreCard, List<int> scores);

        int DeleteScoreCardById(int scoreCardId);

        int GetUserCount();

        User GetUserById(int id);
    }
}
