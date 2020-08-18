using System.ComponentModel.DataAnnotations;

namespace MuseuApi.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }
        
        public string Senha { get; set; }
    }
}