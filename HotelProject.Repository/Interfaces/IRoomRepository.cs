

using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRooms();
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
        Task<Room> ShowSingleRoom(int id);
        Task<List<Room>> GetAllRoomsOfHotel(int hotelId);
    }
}
