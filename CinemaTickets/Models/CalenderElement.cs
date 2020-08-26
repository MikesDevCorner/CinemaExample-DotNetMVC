using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Models
{
    public class CalenderElement
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public Movie Movie { get; set; }
    }
}