namespace TestAsp.Models
{
    public class Note
    {
        public double NoteEval { get; set; }
        public DateTime DateEval { get; set; }
        public int EtudiantId { get; set; }
        public  virtual Etudiant? Etudiant { get; set; }
        public string? MatiereId { get; set; }
        public virtual Matiere? Matiere { get; set; }
    }
}
