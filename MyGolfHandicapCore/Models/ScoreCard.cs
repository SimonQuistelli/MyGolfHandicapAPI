using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGolfHandicapCore.Models
{
    public class ScoreCard
    {
        public int ScoreCardId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GolfCourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string TeeColour { get; set; }
        [Required]
        public int RoundType { get; set; }
        [Required]
        public int Par { get; set; }
        [Required]
        public int GrossScore { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<HoleScore> HoleScores { get; set; }
        public decimal CourseRating { get; set; }
        public int SlopeRating { get; set; }
        public decimal ScoreDiff { get; set; }
        public decimal HandicapIndex { get; set; }
  
        [NotMapped]
        public string HolesPlayed { get { return GetHolesPlayed(); } }

        [NotMapped]
        public string Score { get { return GetScore(); } }
        public string GetHolesPlayed()
        {
            string holesPlayed;

            switch (RoundType)
            {
                case 1:
                    holesPlayed = "Full 18";
                    break;
                case 2:
                    holesPlayed = "Front 9";
                    break;
                case 3:
                    holesPlayed = "Back 9";
                    break;
                default:
                    holesPlayed = "Full 18";
                    break;
            }

            return holesPlayed;
        }

        public string GetScore()
        {
            int par = 0;
            string score;

            foreach (HoleScore hole in HoleScores)
            {
                par += hole.HolePar;
            }

            score = String.Format("+{0}", GrossScore - par);
            return score;
        }
    }
}
