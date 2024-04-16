using HotelProject.Models;
using HotelProject.Repository;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MSDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProjectWeb.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;

        public RoomsController(IRoomRepository roomRepository, IHotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _roomRepository.GetRooms();
            return View(rooms);
        }

        public async Task<IActionResult> Create()
        {
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.Hotels = new SelectList(hotels, "Id", "HotelName");
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
            var hotels = await _hotelRepository.GetHotels();
            ViewBag.Hotels = new SelectList(hotels, "Id", "HotelName");
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
