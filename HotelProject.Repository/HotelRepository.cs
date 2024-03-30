using HotelProject.Data;
using HotelProject.Model;
using HotelProjectModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepository
    {

        public List<Hotel> GetHotels()
        {
            List<Hotel> result = new();
            const string sqlSel = "SELECT * FROM Hotels";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Hotel
                            {
                                Id = reader.GetInt32(0),
                                HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                Rating = reader.GetDouble(2),
                                Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                PhisicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty,
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }

            return result;
        }

        public void AddHotel(Hotel hotel)
        {
            string sqlAdd = @$"INSERT INTO Hotels(HotelName, Rating, Country, City, PhisicalAddress)VALUES(N'{hotel.HotelName}', {hotel.Rating}, N'{hotel.Country}', N'{hotel.City}', N'{hotel.PhisicalAddress}')";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlAdd, connection);
                    connection.Open();
                    command.ExecuteNonQuery();



                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }

        }

        public void UpdateHotel(Hotel hotel)
        {
            int hotelCount = 0;
            const string sqlSel = "SELECT COUNT (*) FROM Hotels";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            hotelCount = reader.GetInt32(0);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }

            if (hotel.Id <= hotelCount)
            {

                string sqlUpdate = @$"UPDATE Hotels SET HotelName = N'{hotel.HotelName}',Rating = {hotel.Rating}, Country = N'{hotel.Country}', City = N'{hotel.City}', PhisicalAddress = N'{hotel.PhisicalAddress}' WHERE Id = {hotel.Id}";

                using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        connection.Open();
                        command.ExecuteNonQuery();



                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }

            }
            else
            {
                throw new Exception();
            }


        }

        public void DeleteHotel(Hotel hotel)
        {
            string sqlDelete = @$"DELETE FROM Hotels WHERE HotelName = N'{hotel.HotelName}'";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    connection.Open();
                    command.ExecuteNonQuery();



                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
