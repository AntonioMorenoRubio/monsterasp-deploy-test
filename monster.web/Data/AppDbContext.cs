using Microsoft.EntityFrameworkCore;
using monster.web.Domain.Entities;

namespace monster.web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Temporada> Temporadas { get; set; }
    public DbSet<Jugador> Jugadores { get; set; }
    public DbSet<Barco> Barcos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configuraciones adicionales si son necesarias
    }
}