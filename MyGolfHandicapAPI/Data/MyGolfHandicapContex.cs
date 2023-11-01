using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using MyGolfHandicapCore.Models;

namespace MyGolfHandicapAPI.Data
{
    public class MyGolfHandicapContext : DbContext
    {
        public MyGolfHandicapContext(DbContextOptions<MyGolfHandicapContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }
        public DbSet<Tee> Tees { get; set; }
        public DbSet<HoleInfo> Holes { get; set; }
        public DbSet<ScoreCard> ScoreCards { get; set; }
        public DbSet<HoleScore> HoleScores { get; set; }
   
        public MyGolfHandicapContext()
        {
            int i = 0;
            i++;
        }
    }
}
