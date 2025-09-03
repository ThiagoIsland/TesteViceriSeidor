using System;
using System.Collections.Generic;


namespace SuperHeroi.Domain.Entities
{
    public partial class Superpoderes
    {
        //public Superpoderes()
        //{
        //    HeroisSuperpoderes = new HashSet<HeroisSuperpoderes>();
        //}

        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
