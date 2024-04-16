using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.MSDataSQLClient
{
    public class ManagerRepository : IManagerRepository
    {
        public async Task<List<Manager>> GetManagers()
        {
            List<Manager> result = new();
            const string sqlSel = "sp_GetAllManagers";

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
                            result.Add(new Manager
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                              //  HotelName = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                HotelId = !reader.IsDBNull(4) ? reader.GetInt32(4) : 0
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

        public async Task AddManager(Manager manager)
        {
            string sqlAdd = "sp_AddManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlAdd, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("firstName", manager.FirstName);
                    command.Parameters.AddWithValue("lastName", manager.LastName);
                    command.Parameters.AddWithValue("hotelID", manager.HotelId);


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

        public async Task UpdateManager(Manager manager)
        {

            string sqlUpdate = "sp_UpdateManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlUpdate, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("firstName", manager.FirstName);
                    command.Parameters.AddWithValue("lastName", manager.LastName);
                    command.Parameters.AddWithValue("hotelID", manager.HotelId);
                    command.Parameters.AddWithValue("id", manager.Id);

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

        public async Task DeleteManager(int id)
        {
            string sqlDelete = "sp_DeleteManager";

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

        public async Task<Manager> ShowSingleManager(int id)
        {
            Manager result = new();
            const string sqlSel = "sp_ShowSingleManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlSel, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("managerId", id);

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.FirstName = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
                            result.LastName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.HotelId = !reader.IsDBNull(2) ? reader.GetInt32(2) : 0;


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
