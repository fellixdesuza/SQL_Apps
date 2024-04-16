using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MSDataSQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProjectWeb.Controllers
{
    public class ManagersController : Controller
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IHotelRepository _hotelRepository;

        public ManagersController(IHotelRepository hotelRepository,IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
            _hotelRepository = hotelRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Manager> managers = await _managerRepository.GetManagers();
            return View(managers);
        }
        public async  Task<IActionResult> Create()
        {
            var hotels =await _hotelRepository.GetHotelsWithoutManager();
            ViewBag.HotelId = new SelectList(hotels, "Id", "HotelName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePOST(Manager model)
        {
            await _managerRepository.AddManager(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _managerRepository.ShowSingleManager(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _managerRepository.DeleteManager(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _managerRepository.ShowSingleManager(id);
            var hotels = await _hotelRepository.GetHotelsWithoutManager();
            ViewBag.HotelsWithoutManagers = new SelectList(hotels, "Id", "Name");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Manager model)
        {
            await _managerRepository.UpdateManager(model);
            return RedirectToAction("Index");
        }
    }
}
