using System;
using System.Collections.Generic;

namespace SuperHeroi.Domain.Entities
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public int SuperpoderId { get; set; }

        public Herois Heroi { get; set; }
        public Superpoderes Superpoder { get; set; }

        public HeroisSuperpoderes(int heroiId, int superpoderId)
        {
            HeroiId = heroiId;
            SuperpoderId = superpoderId;
        }
    }
}
