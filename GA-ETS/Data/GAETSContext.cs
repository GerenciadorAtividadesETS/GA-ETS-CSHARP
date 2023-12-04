using GA_ETS.Model;
using Microsoft.EntityFrameworkCore;

namespace GA_ETS.Data;

public class GAETSContext : DbContext
{
    public GAETSContext(DbContextOptions<GAETSContext> options) : base(options) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasIndex(u => u.Edv).IsUnique();
        base.OnModelCreating(modelBuilder);
    }

    // CONTEXTS ENTIDADES
    public DbSet<Usuario> Usuarios { get; set; }
}