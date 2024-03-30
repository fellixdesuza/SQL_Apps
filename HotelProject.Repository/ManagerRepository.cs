using HotelProject.Data;
using HotelProjectModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class ManagerRepository
    {
        public List<Manager> GetManagers()
        {
            List<Manager> result  = new ();
            const string sqlSel = "SELECT * FROM Managers";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {                
                    SqlCommand command = new SqlCommand (sqlSel, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader ();

                    while (reader.Read ())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Manager 
                            {
                            Id = reader.GetInt32(0),
                            FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                            LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty
                            });
                        }
                    }
                        
                }
                catch(Exception)
                {
                    throw;
                }
                finally
                { 
                    connection.Close ();
                }

            }

            return result;
        }

        public void AddManager(Manager manager)
        {
            string sqlAdd= @$"INSERT INTO Managers(FirstName, lastName)VALUES(N'{manager.FirstName}', N'{manager.LastName}')";

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

        public void  UpdateManager(Manager manager)
        {
            int managerCount = 0;
            const string sqlSel = "SELECT COUNT (*) FROM Managers";

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
                            managerCount = reader.GetInt32(0);
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

            if (manager.Id <= managerCount)
            {

                string sqlUpdate = @$"UPDATE Managers SET FirstName = N'{manager.FirstName}', LastName = N'{manager.LastName}' WHERE Id = {manager.Id}";

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

        public void DeleteManager(Manager manager)
        {
            string sqlDelete = @$"DELETE FROM Managers WHERE LastName = N'{manager.LastName}'";

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
