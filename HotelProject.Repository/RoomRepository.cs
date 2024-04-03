using HotelProject.Data;
using HotelProject.Model;
using HotelProject.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class RoomRepository
    {

        public async Task<List<Room>> GetRooms()
        {
            List<Room> result = new();
            const string sqlSel = "sp_GetAllRooms";

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
                            result.Add(new Room
                            {
                                //Id = reader.GetInt32(0),
                                RoomName = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty,
                                IsFree = !reader.IsDBNull(1) ? reader.GetBoolean(1) : false,
                                DailyPrice = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                HotelName = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty
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

        public async Task AddRoom(Room room)
        {
            string sqlAdd = "sp_AddRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlAdd, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("roomName", room.RoomName);
                    command.Parameters.AddWithValue("isFree", room.IsFree);
                    command.Parameters.AddWithValue("dailyPrice", room.DailyPrice);
                    command.Parameters.AddWithValue("hotelId", room.HotelId);


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

        public async Task UpdateRoom(Room room)
        {
            int roomCount = 0;
            const string sqlSel = "SELECT COUNT (*) FROM Rooms";

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
                            roomCount = reader.GetInt32(0);
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
            if (room.Id <= roomCount)
            {

                string sqlUpdate = "sp_UpdateRoom";

                using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        command.CommandType = CommandType.StoredProcedure;


                    
                        command.Parameters.AddWithValue("id", room.Id);
                        command.Parameters.AddWithValue("roomName", room.RoomName);
                        command.Parameters.AddWithValue("isFree", room.IsFree);
                        command.Parameters.AddWithValue("dailyPrice", room.DailyPrice);
                        


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
            else
            {
                throw new Exception();
            }


        }

        public async Task DeleteRoom(int id)
        {
            string sqlDelete = "sp_DeleteRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlDelete, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", id);

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

        public async Task<Room> ShowSingleRoom(int id)
        {
            Room result = new();
            const string sqlSel = "sp_ShowSingleRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("roomId", id);

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Id = reader.GetInt32(0);
                            result.RoomName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.IsFree = !reader.IsDBNull(2) ? reader.GetBoolean(2) : false;
                            result.DailyPrice = !reader.IsDBNull(3) ? reader.GetDouble(3) : 0;
                            result.HotelId = !reader.IsDBNull(4) ? reader.GetInt32(4) : 0;
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
