using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Application.Exceptions;
using SuperHeroi.Application.Interfaces;
using SuperHeroi.Domain.Entities;
using SuperHeroi.Infra.Interfaces;
using SuperHeroi.Infra.Repositories;

namespace SuperHeroi.Application.Services
{
    public class SuperPoderesService : ISuperPoderesService
    {
        private readonly ISuperPoderesRepository _superPoderesRepository;
        public SuperPoderesService(ISuperPoderesRepository superPoderesRepository) => _superPoderesRepository = superPoderesRepository;

        public Task<List<Superpoderes>> ObterTodosSuperPoderes()
        {
            try
            {
                var superPoderes = _superPoderesRepository.ObterTodosSuperPoderes();
                return superPoderes;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<Superpoderes> RegistrarSuperPoder(SuperPoderesDTO superPoderesDTO)
        {
            try
            {
                var poderExistente = await _superPoderesRepository.ObterSuperPoderPeloId(superPoderesDTO.Id);
                if (poderExistente != null)
                {
                    throw new AlreadyExistsException("Esse poder já existe, não podem haver dois poderes iguais");
                }

                Superpoderes superpoderes = new Superpoderes
                {
                    Id = superPoderesDTO.Id,
                    Superpoder = superPoderesDTO.SuperpoderNome,
                    Descricao = superPoderesDTO.Descricao,
                };

                await _superPoderesRepository.RegistrarSuperPoder(superpoderes);
                return superpoderes;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        }
   }

