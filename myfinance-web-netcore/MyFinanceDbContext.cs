
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=localhost;Database=myfinance;TrustServerCertificate=True;User=SA;Password=your_password;MultipleActiveResultSets=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>().ToTable("Transacao").Property(p => p.PlanoContaId).HasColumnName("PlanoConta_Id");
        }   
    }
}