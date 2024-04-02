using HotelProject.Model;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWeb.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomRepository;
        public RoomsController()
        {
            _roomRepository = new RoomRepository();
        }
        public async Task<IActionResult> Index()
        {
            List<Room> rooms = await _roomRepository.GetRooms();
            return View(rooms);
        }
    }
}
