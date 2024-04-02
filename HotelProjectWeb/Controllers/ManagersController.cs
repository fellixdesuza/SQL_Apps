using HotelProject.Model;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWeb.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ManagerRepository _managerRepository;
        public ManagersController()
        {
            _managerRepository = new ManagerRepository();
        }
        public async Task<IActionResult> Index()
        {
            List<Manager> managers = await _managerRepository.GetManagers();
            return View(managers);
        }
    }
}
