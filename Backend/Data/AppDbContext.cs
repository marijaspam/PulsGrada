using Microsoft.EntityFrameworkCore;
using PulsGrada.Models;

namespace PulsGrada.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Registracija tablica
        public DbSet<Lokal> Lokali { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Favorit> Favoriti { get; set; }
        public DbSet<Dogadaj> Dogadaji { get; set; }
        public DbSet<Kvart> Kvartovi { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Budući da Favorit u bazi ima PK (korisnik_id, lokal_id),
            // to moramo definirati ovdje jer C# atributi ne podržavaju kompozitne ključeve dobro
            modelBuilder.Entity<Favorit>()
                .HasKey(f => new { f.KorisnikId, f.LokalId });
        }
    }
}