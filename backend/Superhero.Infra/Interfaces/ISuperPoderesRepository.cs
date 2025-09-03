using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.Infra.Interfaces
{
    public interface ISuperPoderesRepository
    {
        Task<List<Superpoderes>> ObterTodosSuperPoderes();
        Task<Superpoderes> RegistrarSuperPoder(Superpoderes superpoder);
        Task<Superpoderes> ObterSuperPoderPeloId(int id);
        Task<Superpoderes> ObterSuperPoderPeloNome(string nomeSuperPoder);

    }
}
