using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.Application.Interfaces
{
    public interface ISuperHeroiService
    {
        Task<Herois> RegistrarSuperHeroi(SuperHeroiDTO heroiDTO);
        Task<List<Herois>> ObterTodosHerois();
        Task<Herois> ObterHeroiPeloId(int id);
        Task<Herois> AtualizarHeroi(int id, SuperHeroiDTO heroiDTO);
        Task RemoverHeroi(int id);
    }
}
