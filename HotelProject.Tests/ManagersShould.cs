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
        public void GetManagers()
        {
            var result = _repository.GetManagers();
        }

        [Fact]

        public void AddNewManager() 
        {
            Manager newManager = new()
            {
                FirstName = "ხათუნა",
                LastName = "ალიევი"
            };

            _repository.AddManager(newManager);
        }

        [Fact]

        public void UpdateExistingManagers()
        {
            Manager newManager = new()
            {
                Id = 2,
                FirstName = "დურუ",
                LastName = "ხურცილავა"
            };

            _repository.UpdateManager(newManager);
        }
        [Fact]

        public void DeleteManagers()
        {
            Manager manager = new()
            {
                LastName = "ალიევი"
            };
            _repository.DeleteManager(manager);
        }
    }
}
