using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.Achievement.DAL
{
    public class ClientAwardDao: IClientAwardDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public int Add(int idClient, int idAward)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_InsertClientAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = -1,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterId);

                SqlParameter ParameterIdClient = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdClient",
                    Value = idClient,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterIdClient);

                SqlParameter ParameterIdAward = new SqlParameter 
                {
                    DbType = DbType.Int32,
                    ParameterName= "@IdAward",
                    Value = idAward,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterIdAward);

                connection.Open();
                commnad.ExecuteNonQuery();

                return (int)ParameterId.Value;
            }
        }

        public ClientAward Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_DeleteClientAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterId);

                connection.Open();

                var reader = commnad.ExecuteReader();

                if (reader.Read())
                {
                    return new ClientAward
                    {
                        Id = (int)reader["Id"],
                        IdClient = (int)reader["IdClient"],
                        IdAchievement = (int)reader["IdAchievement"]
                    };
                }
                return null;
            }
        }

        public IEnumerable<ClientAward> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_GetAllClientAward]";

                connection.Open();

                var reader = command.ExecuteReader();

                var clientAward = new List<ClientAward>();

                while (reader.Read())
                {
                    clientAward.Add(new ClientAward
                    {
                        Id = (int)reader["Id"],
                        IdAchievement = (int)reader["IdAchievement"],
                        IdClient = (int)reader["IdClient"]
                    });
                }

                return clientAward;
            }
        }

        public ClientAward GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_GetAwardClientById]";

                SqlParameter ParameterId = new SqlParameter 
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterId);

                connection.Open();

                var reader = commnad.ExecuteReader();

                if (reader.Read())
                {
                    return new ClientAward 
                    {
                        Id = (int)reader["Id"],
                        IdAchievement = (int)reader["IdAchievement"],
                        IdClient = (int)reader["IdClient"]
                    };
                }

                return null;
            }
        }

        public ClientAward Update(ClientAward clientAward)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_UpdateClientAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = clientAward.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterId);

                SqlParameter ParameterIdClient = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdClient",
                    Value = clientAward.IdClient,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterIdClient);

                SqlParameter ParameterIdAward = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdAward",
                    Value = clientAward.IdAchievement,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterIdAward);

                connection.Open();

                command.ExecuteNonQuery();

                //Бред какой то
                return clientAward;
            }
        }



/// /////////////////////////////////////////////////

        public IEnumerable<ClientAward> DeleteByIdAward(int idAward)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientAward> DeleteByIdClient(int idClient)
        {
            throw new NotImplementedException();
        }
    }
}
