using System.Collections.Generic;
using System.Threading.Tasks;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.Infra.Interfaces
{
    public interface ISuperHeroiRepository
    {
        Task<Herois> RegistrarSuperHeroi(Herois heroi);
        Task<List<Herois>> ObterTodosHerois();
        Task<Herois> ObterHeroiPeloId(int Id);
        Task<Herois> ObterHeroiPeloNome(string nome);
        Task RemoverHeroi(Herois heroi);
    }
}
