using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGolfHandicapCore.Models
{
    public class ScoreDifferential
    {
        public DateTime Date { get; set; }
        public decimal ScoreDiff { get; set; }
    }
}
