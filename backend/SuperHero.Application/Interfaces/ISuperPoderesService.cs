using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.Application.Interfaces
{
    public interface ISuperPoderesService
    {
        Task<List<Superpoderes>> ObterTodosSuperPoderes();
        Task<Superpoderes> RegistrarSuperPoder(SuperPoderesDTO superPoderesDTO);
    }
}
