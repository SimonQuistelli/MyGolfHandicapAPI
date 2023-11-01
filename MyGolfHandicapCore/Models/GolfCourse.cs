using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyGolfHandicapCore.Models
{
    public class GolfCourse
    {
        public int GolfCourseId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Tee> Tees { get; set; }
    }
}
