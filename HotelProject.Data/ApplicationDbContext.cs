
using HotelProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    HotelName = "Transilvania",
                    Rating = 7.0,
                    Country = "Hungary",
                    City = "Budapest",
                    PhisicalAddress = "Forest Transilvania"
                },
                new Hotel()
                {
                    Id = 2,
                    HotelName = "Tvaladuri",
                    Rating = 10.0,
                    Country = "Sakartvelo",
                    City = "Kaspi",
                    PhisicalAddress = "Village Tvaladi"
                },
                new Hotel()
                {
                    Id = 3,
                    HotelName = "Continental",
                    Rating = 15.0,
                    Country = "USA",
                    City = "New-York",
                    PhisicalAddress = "Manhattan"
                }
                );

            modelBuilder.Entity<Manager>().HasData(
               new Manager()
               {
                   Id = 1,
                   FirstName = "ჯუმბერ",
                   LastName = "ტყაბლაძე",
                   HotelId = 1
               },
               new Manager()
               {
                   Id = 2,
                   FirstName = "დონალდ",
                   LastName = "ტრამპი",
                   HotelId = 2
               },
               new Manager()
               {
                   Id = 3,
                   FirstName = "სადამ",
                   LastName = "ჰუსეინი",
                   HotelId = 3
               }
               );

            modelBuilder.Entity<Room>().HasData(
               new Room()
               {
                   Id = 1,
                   RoomName = "101",
                   IsFree = true,
                   DailyPrice = 100,
                   HotelId = 1
               },
              new Room()
              {
                  Id = 2,
                  RoomName = "102",
                  IsFree = true,
                  DailyPrice = 90,
                  HotelId = 1
              },
              new Room()
              {
                  Id = 3,
                  RoomName = "103",
                  IsFree = false,
                  DailyPrice = 150,
                  HotelId = 1
              },
              new Room()
              {
                  Id = 4,
                  RoomName = "A1",
                  IsFree = true,
                  DailyPrice = 50,
                  HotelId = 2
              },
              new Room()
              {
                  Id = 5,
                  RoomName = "A2",
                  IsFree = false,
                  DailyPrice = 60,
                  HotelId = 2
              },
              new Room()
              {
                  Id = 6,
                  RoomName = "B1",
                  IsFree = true,
                  DailyPrice = 70,
                  HotelId = 2
              },
              new Room()
              {
                  Id = 7,
                  RoomName = "101",
                  IsFree = false,
                  DailyPrice = 1000,
                  HotelId = 3
              },
               new Room()
               {
                   Id = 8,
                   RoomName = "201",
                   IsFree = true,
                   DailyPrice = 1000,
                   HotelId = 3
               },
                new Room()
                {
                    Id = 9,
                    RoomName = "301",
                    IsFree = true,
                    DailyPrice = 1000,
                    HotelId = 3
                }
               );
        }

        public static string ConnectionString { get; } = "Server=WorkHorse\\SQLEXPRESS;Database=Hotels2;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
