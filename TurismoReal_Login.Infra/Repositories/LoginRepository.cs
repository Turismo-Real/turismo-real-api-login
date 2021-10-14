using TurismoReal_Login.Core.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Threading.Tasks;

namespace TurismoReal_Login.Infra.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<bool> LoginAsync(string email, string pass)
        {
            OracleConnection con = new OracleConnection(Environment.GetEnvironmentVariable("DB_CONNECTION"));
            con.Open();
            OracleCommand cmd = new OracleCommand("sp_login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.BindByName = true;

            cmd.Parameters.Add("email", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add("login", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters["email"].Value = email;
            cmd.Parameters["pass"].Value = pass;

            await cmd.ExecuteNonQueryAsync();
            con.Close();

            int login = int.Parse(cmd.Parameters["login"].Value.ToString());
            if (login == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
