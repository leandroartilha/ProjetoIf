using Microsoft.EntityFrameworkCore;
using ProjetoIF.Models;

namespace ProjetoIF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Login> Login { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<ProjetoIF.Models.AtribuicaoUserProject>? AtribuicaoUserProject { get; set; }


        public DbSet<ProjetoIF.Models.AtribuicaoUserTask>? AtribuicaoUserTask { get; set; }

    }
}