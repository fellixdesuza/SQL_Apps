

using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IHotelRepository
    {
       Task<List<Hotel>> GetHotels();
       Task AddHotel(Hotel hotel);
       Task UpdateHotel(Hotel hotel);
       Task DeleteHotel(int id);
       Task<Hotel> ShowSingleHotel(int id);
       Task<List<Hotel>> GetHotelsWithoutManager();
    }
}
