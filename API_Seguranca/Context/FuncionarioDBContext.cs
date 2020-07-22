using API_Seguranca.Models;
using System.Data.Entity;

namespace API_Seguranca.Context
{
    public class FuncionarioDBContext : DbContext
    {
        public FuncionarioDBContext() : base("name=FuncionarioDBContext") { }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}