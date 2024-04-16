using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MSDataSQLClient;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWeb.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelsController(IHotelRepository hotelrepository) 
        {
            _hotelRepository = hotelrepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Hotel> hotels = await _hotelRepository.GetHotels();
            return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePOST(Hotel model)
        {
            await _hotelRepository.AddHotel(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelRepository.ShowSingleHotel(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _hotelRepository.DeleteHotel(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _hotelRepository.ShowSingleHotel(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Hotel model)
        {
            await _hotelRepository.UpdateHotel(model);
            return RedirectToAction("Index");
        }
    }
}
