using Microsoft.EntityFrameworkCore;


namespace quintogiorno.Models
{
    public class VerbaliContext : DbContext
    {
        public VerbaliContext(DbContextOptions<VerbaliContext> options) : base(options) { }

        public DbSet<Anagrafica> Anagraficas { get; set; }
        public DbSet<TipoViolazione> TipoViolaziones { get; set; }
        public DbSet<Verbale> Verbales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anagrafica>()
                .HasKey(a => a.IDAnagrafica);

            modelBuilder.Entity<TipoViolazione>()
                .HasKey(t => t.IDViolazione);

            modelBuilder.Entity<Verbale>()
                .HasKey(v => v.IDVerbale);

            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Anagrafica)
                .WithMany()
                .HasForeignKey(v => v.IDAnagrafica);

            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.TipoViolazione)
                .WithMany()
                .HasForeignKey(v => v.IDViolazione);
        }
    }
}
