using HotelProject.Repository;
using HotelProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Tests
{
    public class ManagersShould
    {
        private readonly ManagerRepository _repository;
        public ManagersShould() 
        {
            _repository = new();
        }

        [Fact]
        public async void GetManagers()
        {
            var result = await _repository.GetManagers();
        }

        [Fact]

        public async void AddNewManager() 
        {
            Manager newManager = new()
            {
                FirstName = "ტატიანა",
                LastName = "კოტოვა",
                HotelId = 5
            };

            await _repository.AddManager(newManager);
        }

        [Fact]

        public async void UpdateExistingManagers()
        {
            Manager newManager = new()
            {
                Id = 1,
                FirstName = "მია",
                LastName = "ხალიფაშვილი",
                HotelId = 1
            };

            await _repository.UpdateManager(newManager);
        }
        [Fact]

        public async void DeleteManagers()
        {
            await _repository.DeleteManager(1);
        }

        [Fact]
        public async void GetSingleManager()
        {
            var result = await _repository.ShowSingleManager(1);
        }
    }
}
