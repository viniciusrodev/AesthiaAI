using AesthiaAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AesthiaAI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Clinica> Clinicas => Set<Clinica>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        public DbSet<Esteticista> Esteticistas => Set<Esteticista>();

        public DbSet<Cliente> Clientes => Set<Cliente>();

        public DbSet<Servico> Servicos => Set<Servico>();  

        public DbSet<AgendaServico> AgendaServicos => Set<AgendaServico>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
