using System.ComponentModel.DataAnnotations;

namespace TestAsp.Models
{
    public class Enseignant : Personne
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePriseFonct { get; set; }

        public string? MatiereId { get; set; }
        public virtual Matiere? Matiere { get; set; }

        public int DepartementId { get; set; }
        public virtual Departement? Departement { get; set; }
    }
}
