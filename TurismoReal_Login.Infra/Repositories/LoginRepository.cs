using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Threading.Tasks;
using TurismoReal_Login.Core.DTOs;
using TurismoReal_Login.Core.Interfaces;
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

        public async Task<ResponseOK> LoginAsync(string email, string pass)
        {
            try
            {
                _context.OpenConnection();
                OracleCommand cmd = new OracleCommand("sp_login", _context.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.BindByName = true;
                cmd.Parameters.Add("email_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("pass_u", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("tipo_u", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;

                cmd.Parameters["email_u"].Value = email;
                cmd.Parameters["pass_u"].Value = pass;

                await cmd.ExecuteNonQueryAsync();
                _context.CloseConnection();

                string tipo = cmd.Parameters["tipo_u"].Value.ToString();
                Console.WriteLine(tipo);

                if (tipo.CompareTo("ERROR") == 0)
                {
                    return new ResponseOK("Usuario No Autorizado.", false, "");
                }

                return new ResponseOK("Usuario Autorizado.", true, tipo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResponseOK("ERROR", false, String.Empty);
            }
    }
    }
}
