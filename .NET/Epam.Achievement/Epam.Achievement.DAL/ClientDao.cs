using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Achievement.DAL
{
    public class ClientDao : IClientDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public int Add(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_InsertClient]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = client.Id,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(ParameterId);

                SqlParameter ParameterName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = client.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterName);

                SqlParameter ParameterAge = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Age",
                    Value = client.Age,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterAge);

                SqlParameter ParameterDateOfBirth = new SqlParameter
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Value = client.DataOfBirth,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterDateOfBirth);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)ParameterId.Value;
            }
        }

        public Client Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_DeleteClient]";

                SqlParameter Parameterid = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(Parameterid);

                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Client
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DataOfBirth = (DateTime)reader["DataOfBirth"]
                    };
                }
                return null;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_GetAllClients]";

                connection.Open();

                var reader = commnad.ExecuteReader();

                List<Client> clients = new List<Client>();
                

                while (reader.Read())
                {
 
                    clients.Add(new Client
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DataOfBirth = (DateTime)reader["DataOfBirth"]
                    });
                }

                return clients;
            }
        }

        public Client GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_GetClientById]";

                SqlParameter Parameter = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(Parameter);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Client
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DataOfBirth = (DateTime)reader["DataOfBirth"]
                    };
                }

                return null;
            }
        }

        public Client Update(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_UpdateClient]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = client.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterId);

                SqlParameter ParameterName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "Name",
                    Value = client.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterName);

                SqlParameter ParameterAge = new SqlParameter 
                {
                    DbType = DbType.Int32,
                    ParameterName = "Age",
                    Value = client.Age,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterAge);

                SqlParameter ParameterDateOfBirth = new SqlParameter
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@DataOfBirth",
                    Value = client.DataOfBirth,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(ParameterDateOfBirth);

                connection.Open();

                command.ExecuteNonQuery();

                return client;
            }
        }
    }
}
