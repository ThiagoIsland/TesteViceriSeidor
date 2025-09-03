using System;
using System.Collections.Generic;
using System.Text;
using SuperHeroi.Domain.Entities;
using System.Threading.Tasks;

namespace SuperHeroi.Infra.Interfaces
{
    public interface IHeroiSuperPoderesRepository
    {
        Task AdicionarPoderesSuperHeroiPeloId(List<HeroisSuperpoderes> heroisSuperpoderes);
        Task<List<HeroisSuperpoderes>> ObterPoderesSuperHeroiPeloId(int heroiId);
        Task RemoverPoderesSuperHeroiPeloId(List<HeroisSuperpoderes> heroisSuperpoderes);
    }
}
