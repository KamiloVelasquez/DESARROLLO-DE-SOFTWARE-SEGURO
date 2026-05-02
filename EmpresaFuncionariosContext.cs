using Microsoft.EntityFrameworkCore;

namespace GestionFuncionarios
{
    public class EmpresaFuncionariosContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usar SQLite para simplicidad
            optionsBuilder.UseSqlite("Data Source=empresa_funcionarios.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales si es necesario
        }
    }
}