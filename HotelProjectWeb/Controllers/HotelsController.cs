﻿using HotelProject.Model;
using HotelProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWeb.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelRepository _hotelRepository;
        public HotelsController() 
        { 
            _hotelRepository = new HotelRepository();
        }
        public async Task<IActionResult> Index()
        {
            List<Hotel> hotels = await _hotelRepository.GetHotels();
            return View(hotels);
        }
    }
}