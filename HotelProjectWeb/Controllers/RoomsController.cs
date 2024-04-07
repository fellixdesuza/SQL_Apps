using HotelProject.Model;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProjectWeb.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomRepository _roomRepository;
       
        public RoomsController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Room> rooms = await _roomRepository.GetRooms();
            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePOST(Room model)
        {
            await _roomRepository.AddRoom(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomRepository.ShowSingleRoom(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _roomRepository.ShowSingleRoom(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Room model)
        {
            await _roomRepository.UpdateRoom(model);
            return RedirectToAction("Index");
        }
    }
}
