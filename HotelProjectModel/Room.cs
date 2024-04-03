using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public bool IsFree { get; set; }
        public double DailyPrice { get; set; }
        public int HotelId { get; set; }

        public string HotelName { get; set; }

    }
}
