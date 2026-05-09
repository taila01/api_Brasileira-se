using Microsoft.EntityFrameworkCore;
using api_brasileira_se.Models;

namespace api_brasileira_se.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<PontoTuristico> PontosTuristicos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PontoTuristico>().ToTable("PontoTuristico");
    }
}