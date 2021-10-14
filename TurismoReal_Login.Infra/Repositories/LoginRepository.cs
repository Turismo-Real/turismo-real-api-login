using TurismoReal_Login.Core.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Threading.Tasks;
using TurismoReal_Login.Infra.Context;

namespace TurismoReal_Login.Infra.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        protected readonly OracleContext _context;

        public LoginRepository()
        {
            _context = new OracleContext();
        }

        public async Task<bool> LoginAsync(string email, string pass)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_login", _context.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.BindByName = true;
            cmd.Parameters.Add("email", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add("login", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters["email"].Value = email;
            cmd.Parameters["pass"].Value = pass;

            await cmd.ExecuteNonQueryAsync();
            _context.CloseConnection();

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
