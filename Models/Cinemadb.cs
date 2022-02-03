using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE.Models
{
    public class Cinemadb
    {
        [Key]
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaType { get; set; }
        public string CinemaLang { get; set; }
        public int TicketPrice { get; set; }
    }
}