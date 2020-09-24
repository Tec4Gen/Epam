using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.Achievement.DAL
{
    public class AwardDao : IAwardDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public int Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_InsertAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = award.Id,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(ParameterId);

                SqlParameter ParameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = award.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterTitle);

                SqlParameter ParameterImage = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Image",
                    Value = award.Image,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterImage);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)ParameterId.Value;

            }
        }

        public Award Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_DeleteAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterId);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Image = reader["Image"] as byte[]
                    };
                }

                return null;

            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_GetAllAward]";

                connection.Open();

                var reader = command.ExecuteReader();

                var awards = new List<Award>();

                while (reader.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Image = reader["Image"] as byte[]
                    });
                }

                return awards;
            }
        }

        public Award GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_GetAwardById]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterId);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Image = reader["Image"] as byte[]
                    };
                }
                return null;
            }
        }

        public Award Update(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[Sp_UpdateAward]";

                SqlParameter ParameterId = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = award.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterId);

                SqlParameter ParameterTitle = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Title",
                    Value = award.Title,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterTitle);

                SqlParameter ParameterImage = new SqlParameter
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Image",
                    Value = award.Image,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ParameterImage);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Image = reader["Image"] as byte[]
                    };
                }
                return null;

            }
        }
    }
}
