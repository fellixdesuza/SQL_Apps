using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestRepository
    {

        Task<List<Guest>> GetAll();
        Task<Guest> GetById(int id);
        Task<Guest> GetByPin(string personalNumber);
        Task Add(Guest guest);
        Task Update(Guest guest);
        Task Delete(int id);
    }
}
