using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyGolfHandicapCore.Models
{
    public class HoleInfo
    {
        public int HoleInfoId { get; set; }
        public int TeeId { get; set; }
        [Required]
        public int HoleNumber { get; set; }
        [Required]
        public int Par { get; set; }
        [Required]
        public int StrokeIndex { get; set; }
        [Required]
        public int Yards { get; set; }
    }
}
