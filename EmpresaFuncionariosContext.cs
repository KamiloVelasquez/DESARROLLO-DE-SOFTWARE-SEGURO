using Microsoft.EntityFrameworkCore;

namespace GestionFuncionarios
{
    public class EmpresaFuncionariosContext : DbContext
    {
        private const string ConexionMySql = "server=127.0.0.1;port=3306;database=empresa_funcionarios;user=root;password=root;SslMode=Preferred;";

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usar MySQL con la base de datos empresa_funcionarios
            optionsBuilder.UseMySql(ConexionMySql, ServerVersion.AutoDetect(ConexionMySql));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales si es necesario
        }
    }
}