using Epam.Achievement.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.Achievement.DAL
{
    public class MyRoleDao: IMyRoleDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public bool IsUserInRole(string username, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_GetRole]";

                SqlParameter ParameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterUserName);

                SqlParameter ParameterRoleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Role",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterRoleName);

                connection.Open();

                var resultRole = commnad.ExecuteScalar() as string;
                
                return resultRole == roleName ? true: false;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_GetRole]";

                connection.Open();

                List<string> listRole = new List<string>();

                var reader = commnad.ExecuteReader();

                while (reader.Read())
                {
                    listRole.Add(reader["Role"] as string);
                }

                return listRole.ToArray();
            }
        }
    }
}
