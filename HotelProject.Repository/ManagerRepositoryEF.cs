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
    public class ManagerRepositoryEF : IManagerRepository
    {
        private readonly ApplicationDbContext _context;
        public ManagerRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddManager(Manager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }
            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManager(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            var entity = await _context.Managers.FirstAsync(h => h.Id == id);
            _context.Managers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Manager>> GetManagers()
        {
            var entity = await _context.Managers.Include(nameof(Hotel)).ToListAsync();
            if (entity == null)
            {
                throw new NullReferenceException("Entities not found");
            }
            return entity;
        }

        public async Task<Manager> ShowSingleManager(int id)
        {
            var entity = await _context.Managers.Include(nameof(Hotel)).FirstAsync(h => h.Id == id);
            return entity;
        }

        public async Task UpdateManager(Manager manager)
        {
            if (manager == null || manager.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            var entity = await _context.Managers.FirstAsync(m => m.Id == manager.Id);
            entity.FirstName = manager.FirstName;
            entity.LastName = manager.LastName;
            if (manager.HotelId == 0)
            {
                manager.HotelId = entity.HotelId;
            }
           

            _context.Managers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
