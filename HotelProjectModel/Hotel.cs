using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public double Rating { get; set; }
        public string Country {  get; set; }
        public string City { get; set; }
        public string PhisicalAddress { get; set; }
    }
}
