using Agendei.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agendei.Infra.Contexts
{
    public class AgendeiContext : DbContext
    {
        public AgendeiContext(DbContextOptions<AgendeiContext> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}