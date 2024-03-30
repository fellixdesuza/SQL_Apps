using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Data
{
    public static class ApplicationDbContext
    {
        public static string ConnectionString { get; } = "Server=WorkHorse\\SQLEXPRESS;Database=Hotels;Trusted_Connection=True;TrustServerCertificate=True";

    }
}
