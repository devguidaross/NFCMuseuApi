using System;
using System.ComponentModel.DataAnnotations;

namespace MuseuApi.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ordem { get; set; }
        public string Familia { get; set; }
        public string Descricao { get; set; }
        public string DistribuicaoGeografica { get; set; }
        public string Habitat { get; set; }
        public string HabitosAlimentares { get; set; }
        public string Reproducao { get; set; }
        public string PeriodoDeVida { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }
        
        //fully defined relationship
        //public int? GradeId { get; set; }

        //public virtual Grade Grade { get; set; }

        //public virtual StudentAddress Address { get; set; }
        //public virtual ICollection<Course> Courses { get; set; }
    }
}