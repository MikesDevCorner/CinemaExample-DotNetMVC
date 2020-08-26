using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Models
{
    public class Cart : List<CalenderElement>
    {
        public User User { get; set; }

        public double CartPrice
        {
            get
            {
                double price = 0.0d;
                foreach(CalenderElement c in this) {
                    price += c.Movie.Price;
                }
                return price;
            }
        }
    }
}