using System.ComponentModel.DataAnnotations;

namespace TestAsp.Models
{
    public class Personne
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
    }
}
