

using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetManagers();
        Task AddManager(Manager manager);
        Task UpdateManager(Manager manager);
        Task DeleteManager(int id);
        Task<Manager> ShowSingleManager(int id);

    }
}
