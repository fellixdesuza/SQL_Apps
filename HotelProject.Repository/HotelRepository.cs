using HotelProject.Data;
using HotelProject.Model;
using HotelProjectModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace HotelProject.Repository
{
    public class HotelRepository
    {

        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> result = new();
            const string sqlSel = "sp_GetAllHotels";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

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
                    await connection.CloseAsync();
                }

            }

            return result;
        }

        public async Task AddHotel(Hotel hotel)
        {
            string sqlAdd = "sp_AddHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlAdd, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("name", hotel.HotelName);
                    command.Parameters.AddWithValue("rating", hotel.Rating);
                    command.Parameters.AddWithValue("country", hotel.Country);
                    command.Parameters.AddWithValue("city", hotel.City);
                    command.Parameters.AddWithValue("phyisicalAddress", hotel.PhisicalAddress);

                    await connection.OpenAsync();
                    int rowsEffect = await command.ExecuteNonQueryAsync();

                    if (rowsEffect == 0) {
                        throw new InvalidOperationException("Command effected zero rows");
                    }


                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }

            }

        }

        public async Task UpdateHotel(Hotel hotel)
        {
            int hotelCount = 0;
            const string sqlSel = "SELECT COUNT (*) FROM Hotels";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

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
                    await connection.CloseAsync();
                }

            }

            if (hotel.Id <= hotelCount)
            {

                string sqlUpdate = "sp_UpdateHotel";

                using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("name", hotel.HotelName);
                        command.Parameters.AddWithValue("rating", hotel.Rating);
                        command.Parameters.AddWithValue("country", hotel.Country);
                        command.Parameters.AddWithValue("city", hotel.City);
                        command.Parameters.AddWithValue("phisicalAddress", hotel.PhisicalAddress);
                        command.Parameters.AddWithValue("hotelId", hotel.Id);

                        await connection.OpenAsync();
                        command.ExecuteNonQuery();



                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        await connection.CloseAsync();
                    }

                }

            }
            else
            {
                throw new Exception();
            }


        }

        public async Task DeleteHotel(int id)
        {
            string sqlDelete = "sp_DeleteHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("hotelId", id);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();



                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }

            }
        }

        public async Task<Hotel> ShowSingleHotel(int id)
        {
            Hotel result = new();
            const string sqlSel = "sp_ShowSingleHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("hotelId", id);

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Id = reader.GetInt32(0);
                            result.HotelName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.Rating = reader.GetDouble(2);
                            result.Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                            result.City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            result.PhisicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;

                        } 
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }

            }

            return result;
        }
    }
}
