using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class EtudiantConfiguration : IEntityTypeConfiguration<Etudiant>
    {
        public void Configure(EntityTypeBuilder<Etudiant> builder)
        {
            builder.ToTable("Etudiant", "dbo");
            builder.HasKey(e => e.Matricule);
            builder.Property(e => e.Matricule)
                .IsRequired()
                .UseIdentityColumn(1,1);
            builder.Property(e => e.Nom)
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            builder.Property(e => e.Prenom)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.Adresse)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.DateNais)
                .IsRequired();
            builder.Property(e => e.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);
            builder.Property(e => e.Telephone)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.HasMany(e => e.Notes)
                .WithOne(n => n.Etudiant)
                .HasForeignKey(n => n.EtudiantId);
            builder.HasOne(e => e.Filiere)
                .WithMany(f => f.Etudiants)
                .HasForeignKey(e => e.FiliereId);
            builder.HasCheckConstraint("ck_age", "(year(GETDATE()) - year(DateNais)) >=18");
        }
    }
}
