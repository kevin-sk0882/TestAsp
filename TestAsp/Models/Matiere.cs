namespace TestAsp.Models
{
    public class Matiere
    {
        public string? CodeMat { get; set; }
        public string? Name { get; set; }

        public int SalleId { get; set; }
        public virtual Salle? Salle { get; set; }

        public List<Enseignant>? Enseignants { get; set; }
        public List<Note>? Notes { get; set; }
    }
}
