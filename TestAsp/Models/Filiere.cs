namespace TestAsp.Models
{
    public class Filiere
    {
        public string? CodeFil { get; set; }
        public string? Name { get; set; }

        public List<Etudiant>? Etudiants { get; set; }
    }
}
