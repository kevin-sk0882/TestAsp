namespace TestAsp.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Matiere>? Matieres { get; set; }
    }
}
