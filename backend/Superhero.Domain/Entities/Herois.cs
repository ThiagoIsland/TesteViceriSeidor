using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SuperHeroi.Domain.Entities
{
    public partial class Herois
    {
        //public Herois()
        //{
        //    HeroisSuperpoderes = new HashSet<HeroisSuperpoderes>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

    }
}
