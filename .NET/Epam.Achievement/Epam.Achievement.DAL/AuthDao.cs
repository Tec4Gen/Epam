using Epam.Achievement.DAL.Interface;
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
    public class AuthDao : IAuthDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;
        public bool CanLogin(string user, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var commnad = connection.CreateCommand();

                commnad.CommandType = CommandType.StoredProcedure;
                commnad.CommandText = "[dbo].[Sp_CheckUser]";

                SqlParameter ParameterUserName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterUserName);

                SqlParameter ParameterRoleName = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = password,
                    Direction = ParameterDirection.Input
                };
                commnad.Parameters.Add(ParameterRoleName);

                connection.Open();

                var reader = commnad.ExecuteReader();
                if (reader.Read())
                {
                    if (user == reader["Login"] as string && password == reader["Password"] as string)
                    {
                        return true;
                    }
                }


                return false;
            }
        }
    }
}
