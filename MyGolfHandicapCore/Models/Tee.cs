using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyGolfHandicapCore.Models
{
    public class Tee
    {
        public int TeeId { get; set; }
        public int GolfCourseId { get; set; }
        [Required]
        public string TeeColour { get; set; }
        [Required]
        public decimal CourseRating18 { get; set; }
        [Required]
        public int SlopeRating18 { get; set; }
        [Required]
        public decimal CourseRatingFront9 { get; set; }
        [Required]
        public int SlopeRatingFront9 { get; set; }
        [Required]
        public decimal CourseRatingBack9 { get; set; }
        [Required]
        public int SlopeRatingBack9 { get; set; }

        public ICollection<HoleInfo> Holes { get; set; }
    }
}
