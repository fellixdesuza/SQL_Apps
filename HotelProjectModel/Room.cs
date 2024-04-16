using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomName { get; set; }
        [Required]
        public bool IsFree { get; set; }
        [Required]
        public double DailyPrice { get; set; }
        [Required]
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

      // public string HotelName { get; set; }
       
       
    }
}
