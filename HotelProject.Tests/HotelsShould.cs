using HotelProject.Models;
using HotelProject.Repository.MSDataSQLClient;
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
        public async void GetHotels()
        {
            var result = await _repository.GetHotels();
        }

        [Fact]

        public async void AddNewHotels()
        {
            Hotel newHotel = new()
            {
                HotelName = "Palm",
                Rating = 7.0,
                Country = "Georgia",
                City = "Blikviri",
                PhisicalAddress = "Blikviri Dsitrict, Georgia"
            };

            await _repository.AddHotel(newHotel);
        }

        [Fact]

        public async void UpdateExistingHotels()
        {
            Hotel newHotel = new()
            {
               
                HotelName = "Tvaladuri",
                Rating = 9.99,
                Country = "Sakartvelo",
                City = "Kaspi",
                PhisicalAddress = "Village Tvaladi, Kaspi, Shida Kartli, Georgia",
                Id = 4
            };

            await _repository.UpdateHotel(newHotel);
        }
        [Fact]
        public async void DeleteFromHotel()
        {
          
            await _repository.DeleteHotel(4);
        }

        [Fact]
        public async void GetSingleHotel()
        {
            var result = await _repository.ShowSingleHotel(1);
        }
    }
}
