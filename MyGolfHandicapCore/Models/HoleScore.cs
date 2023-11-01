using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MyGolfHandicapCore.Models
{
    public class HoleScore
    {
        public int HoleScoreId { get; set; }
        public int ScoreCardId { get; set; }
        [Required]
        public int HoleNumber { get; set; }
        [Required]
        public int HolePar { get; set; }
        [Required]
        public int StrokeIndex { get; set; }
        [Required]
        public int Yards { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
