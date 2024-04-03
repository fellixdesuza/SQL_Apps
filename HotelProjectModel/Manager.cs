using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Model
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }

        public int HotelId { get; set; }

        public string HotelName {  get; set; }
    }
}
