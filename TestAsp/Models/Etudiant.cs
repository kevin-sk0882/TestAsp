using System.ComponentModel.DataAnnotations;

namespace TestAsp.Models
{
    public class Etudiant : Personne
    {
        public int Matricule { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNais { get; set; }

        public string? FiliereId { get; set; }
        public virtual Filiere? Filiere { get; set; }

        public List<Note>? Notes { get; set; }
    }
}
