using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestReservationRepository
    {

        Task<List<GuestReservation>> GetAll();
        Task<GuestReservation> GetById(int id);
        Task Add(GuestReservation guest);
        Task Update(GuestReservation guest);
        Task Delete(int id);
    }
}
