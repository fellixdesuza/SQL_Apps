using HotelProject.Model;
using HotelProject.Repository;
using HotelProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Tests
{
    public class HotelsShould
    {
        private readonly HotelRepository _repository;
        public HotelsShould()
        {
            _repository = new();
        }

        [Fact]
        public void GetHotels()
        {
            var result = _repository.GetHotels();
        }

        [Fact]

        public void AddNewHotels()
        {
            Hotel newHotel = new()
            {
                HotelName = "Shato Tvaladi",
                Rating = 10.2,
                Country = "Georgia",
                City = "Kaspi",
                PhisicalAddress = "Vilage Tvaladi, Kaspi, Shida Kartli, Georgia"
            };

            _repository.AddHotel(newHotel);
        }

        [Fact]

        public void UpdateExistingHotels()
        {
            Hotel newHotel = new()
            {
                Id = 4,
                HotelName = "Tvaladuri",
                Rating = 9.99,
                Country = "Sakartvelo",
                City = "Kaspi",
                PhisicalAddress = "Village Tvaladi, Kaspi, Shida Kartli, Georgia"
            };

            _repository.UpdateHotel(newHotel);
        }
        [Fact]
        public void DeleteFromHotel()
        {
            Hotel hotel = new()
            {
                HotelName = "Paragraph"
            };
            _repository.DeleteHotel(hotel);
        }
    }
}
