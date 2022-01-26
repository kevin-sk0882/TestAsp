namespace TestAsp.Models
{
    public class Departement
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Enseignant>? Enseignants { get; set; }
    }
}
