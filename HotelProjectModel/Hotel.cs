using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string HotelName { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country {  get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhisicalAddress { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
