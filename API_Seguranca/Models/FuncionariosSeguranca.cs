using API_Seguranca.Context;
using System;
using System.Linq;

namespace API_Seguranca.Models
{
    public class FuncionariosSeguranca
    {
        public static bool Login(string login, string senha)
        {
            using (FuncionarioDBContext entities = new FuncionarioDBContext())
            {
                return entities.Usuarios.Any(user =>
                    user.Login.Equals(login, StringComparison.OrdinalIgnoreCase)
                    && user.Senha == senha);
            }
        }
    }
}