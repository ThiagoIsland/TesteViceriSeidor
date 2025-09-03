using System;
using System.Collections.Generic;

namespace SuperHeroi.Domain.Entities
{
    public partial class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public int SuperpoderId { get; set; }

        public virtual Herois Heroi { get; set; }
        public virtual Superpoderes Superpoder { get; set; }
    }
}
