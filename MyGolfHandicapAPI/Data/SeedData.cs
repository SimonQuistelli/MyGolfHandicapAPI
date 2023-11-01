using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IMyGolfHandicapRepo repo)
        {
            User simonq;
            User guest;
            GolfCourse bristol;
            GolfCourse churston;
            GolfCourse dartmouth;
            GolfCourse dawlishWarren;

            repo.UpdateDBMigrations();

            if (repo.GetUserCount() == 0)
            {
                simonq = repo.AddUser(Settings.UserName1, Settings.UserPW1);
                guest = repo.AddUser(Settings.UserName2, Settings.UserPW2);
                bristol = AddCourseBristol(repo);
                churston = AddCourseCurston(repo);
                dartmouth = AddCourseDartmouth(repo);
                dawlishWarren = AddCourseDawlishWarren(repo);
                AddScoreCardsBristol(repo, simonq, bristol);
            }
        }
        public static GolfCourse AddCourseBristol(IMyGolfHandicapRepo repo)
        {
            GolfCourse course = repo.AddGolfCourse("The Bristol");
            int i = 0;

            Tee redTee = repo.AddTee(course, "Red", 72.1m, 130, 37.4m, 138, 34.7m, 122);

            int[] redPars = new int[] { 5, 3, 4, 4, 4, 3, 5, 4, 4, 4, 3, 5, 4, 3, 5, 3, 4, 4 };
            int[] redYards = new int[] { 476, 126, 393, 324, 280, 137, 450, 394, 279, 320, 160, 374, 288, 98, 441, 117, 323, 346 };
            int[] strokeIndex = new[] { 9, 17, 3, 7, 15, 13, 5, 1, 11, 12, 6, 8, 14, 18, 2, 16, 4, 10 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(redTee, i + 1, redPars[i], strokeIndex[i], redYards[i]);
            }

            Tee yellowTee = repo.AddTee(course, "Yellow", 68.9m, 128, 35.1m, 130, 33.8m, 125);
            int[] yellowPars = new int[] { 5, 3, 4, 4, 4, 3, 5, 4, 4, 4, 3, 4, 4, 3, 5, 3, 4, 4 };
            int[] yellowYards = new int[] { 499, 147, 402, 348, 294, 149, 466, 403, 300, 346, 208, 442, 316, 122, 475, 161, 350, 359 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(yellowTee, i + 1, yellowPars[i], strokeIndex[i], yellowYards[i]);
            }

            Tee whiteTee = repo.AddTee(course, "White", 70.5m, 135, 35.6m, 140, 34.9m, 129);
            int[] whitePars = new int[] { 5, 3, 4, 4, 4, 3, 5, 4, 4, 4, 3, 4, 4, 3, 5, 3, 4, 4 };
            int[] whiteYards = new int[] { 551, 149, 405, 369, 316, 156, 513, 409, 314, 363, 226, 467, 362, 129, 483, 190, 367, 369 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(whiteTee, i + 1, whitePars[i], strokeIndex[i], whiteYards[i]);
            }

            return course;
        }

        public static GolfCourse AddCourseCurston(IMyGolfHandicapRepo repo)
        {
            GolfCourse course = repo.AddGolfCourse("Churston");
            int i;

            Tee redTee = repo.AddTee(course, "Red", 67.7m, 119, 34.0m, 116, 33.7m, 122);

            int[] redPars = new int[] { 4, 4, 4, 3, 5, 5, 4, 3, 4, 4, 4, 4, 4, 5, 4, 4, 3, 4 };
            int[] redYards = new int[] { 227, 356, 390, 153, 476, 457, 316, 127, 357, 273, 333, 375, 296, 461, 312, 299, 139, 338 };
            int[] strokeIndex = new[] { 17, 7, 3, 11, 9, 13, 5, 15, 1, 14, 6, 2, 16, 8, 4, 10, 18, 12 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(redTee, i + 1, redPars[i], strokeIndex[i], redYards[i]);
            }

            Tee yellowTee = repo.AddTee(course, "Yellow", 69.2m, 122, 34.9m, 117, 34.3m, 127);
            int[] yellowPars = new int[] { 3, 4, 4, 3, 5, 4, 4, 3, 4, 4, 4, 4, 4, 5, 4, 4, 3, 4 };
            int[] yellowYards = new int[] { 233, 371, 422, 159, 531, 479, 325, 151, 375, 284, 328, 397, 301, 515, 332, 318, 161, 333 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(yellowTee, i + 1, yellowPars[i], strokeIndex[i], yellowYards[i]);
            }

            Tee whiteTee = repo.AddTee(course, "White", 70.6m, 126, 35.6m, 123, 35.0m, 129);
            int[] whitePars = new int[] { 3, 4, 4, 3, 5, 4, 4, 3, 4, 4, 4, 4, 4, 5, 4, 4, 3, 4 };
            int[] whiteYards = new int[] { 240, 378, 443, 170, 556, 489, 345, 166, 389, 296, 350, 412, 321, 522, 348, 328, 173, 341 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(whiteTee, i + 1, whitePars[i], strokeIndex[i], whiteYards[i]);
            }

            return course;
        }

        public static GolfCourse AddCourseDartmouth(IMyGolfHandicapRepo repo)
        {
            GolfCourse course = repo.AddGolfCourse("Dartmouth");
            int i;

            Tee redTee = repo.AddTee(course, "Red", 73.6m, 131, 35.8m, 125, 37.8m, 136);

            int[] redPars = new int[] { 4, 4, 3, 5, 3, 4, 3, 5, 5, 4, 5, 4, 4, 4, 5, 5, 4, 3 };
            int[] redYards = new int[] { 334, 279, 138, 442, 119, 312, 154, 470, 439, 330, 395, 325, 293, 379, 374, 456, 302, 161 };
            int[] strokeIndex = new[] { 10, 16, 12, 2, 18, 4, 14, 6, 8, 3, 17, 5, 13, 1, 7, 11, 9, 15 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(redTee, i + 1, redPars[i], strokeIndex[i], redYards[i]);
            }

            Tee yellowTee = repo.AddTee(course, "Blue", 71.3m, 130, 34.8m, 129, 36.5m, 130);
            int[] yellowPars = new int[] { 4, 4, 3, 5, 3, 4, 3, 5, 5, 4, 4, 4, 4, 4, 4, 5, 4, 3 };
            int[] yellowYards = new int[] { 368, 307, 158, 453, 124, 321, 196, 494, 482, 338, 402, 343, 325, 399, 399, 505, 366, 193 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(yellowTee, i + 1, yellowPars[i], strokeIndex[i], yellowYards[i]);
            }

            Tee whiteTee = repo.AddTee(course, "gold", 75.4m, 140, 36.6m, 140, 38.8m, 140);
            int[] whitePars = new int[] { 4, 4, 3, 5, 3, 4, 3, 5, 5, 4, 4, 4, 4, 4, 4, 5, 4, 3 };
            int[] whiteYards = new int[] { 430, 361, 173, 534, 155, 391, 236, 553, 527, 403, 474, 393, 352, 461, 452, 583, 432, 237 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(whiteTee, i + 1, whitePars[i], strokeIndex[i], whiteYards[i]);
            }

            return course;
        }

        public static GolfCourse AddCourseDawlishWarren(IMyGolfHandicapRepo repo)
        {
            GolfCourse course = repo.AddGolfCourse("Dawlish Warren");
            int i;

            Tee redTee = repo.AddTee(course, "Red", 70.7m, 119, 33.4m, 113, 37.3m, 125);

            int[] redPars = new int[] { 4, 4, 3, 5, 3, 4, 4, 3, 4, 5, 5, 5, 3, 4, 4, 3, 5, 4 };
            int[] redYards = new int[] { 273, 310, 161, 423, 141, 297, 291, 158, 328, 401, 451, 433, 128, 266, 273, 153, 381, 385 };
            int[] strokeIndex = new[] { 16, 6, 14, 2, 18, 8, 12, 10, 4, 1, 15, 5, 17, 9, 11, 13, 3, 7 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(redTee, i + 1, redPars[i], strokeIndex[i], redYards[i]);
            }

            Tee yellowTee = repo.AddTee(course, "Yellow", 67.1m, 112, 32.4m, 103, 34.7m, 121);
            int[] yellowPars = new int[] { 4, 4, 3, 4, 3, 4, 4, 3, 4, 4, 5, 5, 3, 4, 4, 3, 4, 4 };
            int[] yellowYards = new int[] { 271, 349, 165, 426, 149, 300, 327, 187, 424, 434, 461, 442, 131, 269, 281, 160, 389, 369 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(yellowTee, i + 1, yellowPars[i], strokeIndex[i], yellowYards[i]);
            }

            Tee whiteTee = repo.AddTee(course, "White", 68.8m, 121, 32.9m, 113, 35.9m, 128);
            int[] whitePars = new int[] { 4, 4, 3, 4, 3, 4, 4, 3, 4, 4, 5, 5, 3, 4, 4, 3, 4, 4 };
            int[] whiteYards = new int[] { 296, 363, 186, 429, 170, 345, 332, 194, 431, 462, 510, 477, 155, 304, 335, 177, 403, 399 };

            for (i = 0; i < 18; i++)
            {
                repo.AddHole(whiteTee, i + 1, whitePars[i], strokeIndex[i], whiteYards[i]);
            }

            return course;
        }

        public static void AddScoreCardsBristol(IMyGolfHandicapRepo repo, User user, GolfCourse bristol)
        {
            Tee yellowTee = bristol.Tees.Where(t => t.TeeColour == "Yellow").FirstOrDefault();

            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 5, 18), new List<int>() { 6, 3, 6, 6, 4, 3, 5, 6, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 5, 22), new List<int>() { 6, 2, 6, 6, 8, 3, 6, 7, 6 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2021, 6, 3), new List<int>() { 6, 3, 9, 6, 7, 3, 5, 5, 7, 4, 4, 7, 4, 5, 5, 4, 5, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2021, 6, 12), new List<int>() { 6, 4, 4, 6, 4, 4, 5, 7, 5, 7, 5, 5, 4, 3, 6, 4, 5, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 6, 15), new List<int>() { 8, 5, 5, 7, 3, 4, 5, 5, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 6, 19), new List<int>() { 5, 5, 6, 5, 3, 4, 6, 6, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 6, 23), new List<int>() { 5, 4, 7, 5, 5, 5, 7, 6, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2021, 8, 15), new List<int>() { 5, 4, 5, 5, 5, 3, 7, 6, 4, 4, 4, 7, 4, 3, 6, 4, 7, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 11, 14), new List<int>() { 5, 3, 7, 6, 4, 3, 4, 6, 6 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 11, 21), new List<int>() { 6, 3, 6, 5, 5, 5, 7, 5, 6 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2021, 11, 28), new List<int>() { 7, 4, 6, 6, 5, 4, 7, 7, 6 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 4, 4), new List<int>() { 6, 4, 6, 6, 4, 6, 6, 7, 4, 6, 3, 6, 6, 3, 6, 5, 5, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 5, 2), new List<int>() { 7, 5, 7, 6, 5, 4, 5, 5, 7, 4, 4, 6, 4, 4, 8, 6, 6, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 5, 7), new List<int>() { 6, 3, 5, 5, 4, 3, 6, 4, 6, 5, 4, 6, 5, 3, 8, 3, 5, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 5, 14), new List<int>() { 7, 4, 4, 5, 5, 4, 5, 4, 4, 5, 5, 5, 5, 4, 5, 5, 7, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 5, 21), new List<int>() { 6, 4, 7, 7, 5, 4, 6, 5, 5, 5, 4, 7, 6, 3, 6, 5, 5, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 5, 28), new List<int>() { 6, 3, 6, 5, 6, 3, 8, 5, 4, 4, 3, 6, 4, 3, 6, 4, 6, 3 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 6, 11), new List<int>() { 8, 4, 7, 5, 5, 4, 5, 6, 7, 7, 4, 4, 4, 4, 5, 4, 5, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 6, 25), new List<int>() { 5, 4, 5, 5, 4, 3, 5, 7, 5, 6, 5, 6, 5, 4, 6, 4, 5, 7 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 1, new DateTime(2022, 7, 2), new List<int>() { 6, 3, 7, 6, 5, 3, 5, 7, 7, 6, 4, 5, 5, 2, 7, 4, 4, 6 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2022, 7, 16), new List<int>() { 5, 4, 6, 5, 5, 4, 6, 5, 5 });
            repo.AddScoreCard(user, bristol, yellowTee.TeeId, 2, new DateTime(2022, 7, 30), new List<int>() { 5, 3, 4, 5, 4, 3, 5, 6, 7 });
        }
    }
}
