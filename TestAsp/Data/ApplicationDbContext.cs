using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Data.Entities_Configuration;
using TestAsp.Models;

namespace TestAsp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DepartementConfiguration());
            modelBuilder.ApplyConfiguration(new EnseignantConfiguration());
            modelBuilder.ApplyConfiguration(new EtudiantConfiguration());
            modelBuilder.ApplyConfiguration(new FiliereConfiguration());
            modelBuilder.ApplyConfiguration(new MatiereConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new SalleConfiguration());
        }
        public virtual DbSet<Departement>? Departements { get; set; }
        public virtual DbSet<Enseignant>? Enseignants { get; set; }
        public virtual DbSet<Etudiant>? Etudiants { get; set; }
        public virtual DbSet<Filiere>? Filieres { get; set; }
        public virtual DbSet<Matiere>? Matieres { get; set; }
        public virtual DbSet<Note>? Notes { get; set; }
        public virtual DbSet<Salle>? Salles { get; set; }
    }
}