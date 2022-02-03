using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE.Models
{
    public class CinemaDbcontext:DbContext
    {
        public CinemaDbcontext()
        {

        }
        public CinemaDbcontext(DbContextOptions<CinemaDbcontext> options) : base(options)
        {

        }
        public DbSet<Cinemadb> cinemadb { get; set; }
        public DbSet<UserInfo> userInfo {get;set;}

    }
}