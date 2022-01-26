using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAsp.Models;

namespace TestAsp.Data.Entities_Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Note", "dbo");
            builder.HasKey(n => new {n.EtudiantId, n.MatiereId});
            builder.Property(n => n.DateEval)
                .IsRequired();
            builder.Property(n => n.NoteEval)
                .IsRequired();
            builder.HasCheckConstraint("ck_note", "NoteEval>=0 and NoteEval<=20");
        }
    }
}
