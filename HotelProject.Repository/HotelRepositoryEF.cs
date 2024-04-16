using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepositoryEF : IHotelRepository
    {
        private readonly ApplicationDbContext _context;
         public HotelRepositoryEF(ApplicationDbContext context)
        {
               _context = context;
        }
        public async Task AddHotel(Hotel hotel)
        {
           if (hotel == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }
           await _context.Hotels.AddAsync(hotel);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            var entity = await _context.Hotels.FirstAsync(h=>h.Id == id);
            _context.Hotels.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var entity = await _context.Hotels.ToListAsync();
            if (entity == null)
            {
                throw new NullReferenceException("Entities not found");
            }
            return entity;
        }

        public async Task<List<Hotel>> GetHotelsWithoutManager()
        {
            var entities = await _context.Hotels.Where(h=> h.Manager == null).ToListAsync();
            return entities;
        }
        public async Task<Hotel> ShowSingleHotel(int id)
        {
            var entity = await _context.Hotels.FirstAsync(h => h.Id == id);
            return entity;
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            if (hotel == null || hotel.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            var entity = await _context.Hotels.FirstAsync(h => h.Id == hotel.Id);
            entity.HotelName = hotel.HotelName;
            entity.Rating = hotel.Rating;
            entity.City = hotel.City;
            entity.Country = hotel.Country;
            entity.PhisicalAddress = hotel.PhisicalAddress;

            _context.Hotels.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
