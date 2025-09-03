using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Application.Exceptions;
using SuperHeroi.Application.Interfaces;
using SuperHeroi.Domain.Entities;
using SuperHeroi.Infra.Interfaces;

namespace SuperHeroi.Application.Services
{
    public class SuperHeroiService : ISuperHeroiService
    {
        private readonly ISuperHeroiRepository _heroiRepository;
        public SuperHeroiService(ISuperHeroiRepository heroiRepository) => _heroiRepository = heroiRepository;

        public async Task<Herois> RegistrarSuperHeroi(SuperHeroiDTO heroiDTO)
        {
            try
            {
                var heroiExistente = await _heroiRepository.ObterHeroiPeloNome(heroiDTO.Nome);
                if (heroiExistente != null)
                {
                    throw new AlreadyExistsException($"Esse héroi já existe, não podem haver dois {heroiDTO.Nome}");
                }

                Herois heroi = new Herois
                {
                  Nome = heroiDTO.Nome,
                  NomeHeroi = heroiDTO.NomeHeroi,
                  DataNascimento = heroiDTO.DataNascimento,
                  Altura = heroiDTO.Altura,
                  Peso = heroiDTO.Peso,
                };

                heroi.HeroisSuperpoderes = heroiDTO.SuperPoderes.Select(poderes => poderes.Id).ToList()
                .Select(superpoderId => new HeroisSuperpoderes { SuperpoderId = superpoderId })
                .ToList();

                return await _heroiRepository.RegistrarSuperHeroi(heroi);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<Herois>> ObterTodosHerois()
        {
            try
            {
                var herois = await _heroiRepository.ObterTodosHerois();
                return herois;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<Herois> ObterHeroiPeloId(int id)
        {
            if (id < 0)
            {
                throw new BadRequestException("Identificação inváldia. Por favor, coloque um ID válido");
            }
            try
            {
                Herois heroi = await _heroiRepository.ObterHeroiPeloId(id);
                if (heroi == null)
                {
                    throw new NotFoundException("Identificação não encontrada. Por favor, coloque um ID existente;");
                }
                return heroi;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<Herois> AtualizarHeroi(int id, SuperHeroiDTO heroiDTO)
        {
            try
            {
                Herois heroi = await _heroiRepository.ObterHeroiPeloId(id);
                if (heroi == null)
                {
                    throw new NotFoundException("Identificação não encontrada. Por favor, coloque um ID existente;");
                }
                var heroiExistente = await _heroiRepository.ObterHeroiPeloNome(heroiDTO.Nome);
                if (heroiExistente != null)
                {
                    throw new AlreadyExistsException("Já existe um héroi com esse nome. Por favor, tente outro nome");
                }

                heroi.Nome = heroiDTO.Nome;
                heroi.NomeHeroi = heroiDTO.NomeHeroi;
                heroi.DataNascimento = heroiDTO.DataNascimento;
                heroi.Altura = heroiDTO.Altura;
                heroi.Peso = heroiDTO.Peso;
                
                List<int> IdsPoderesAtuais = heroi.HeroisSuperpoderes.Select(poderes => poderes.Superpoder.Id).ToList();
                List<int> IdsPoderesnovos = heroiDTO.SuperPoderes.Select(poderes => poderes.Id).ToList();

                return null;
            }
            catch
            {
                throw;
            }
        }
        public async Task RemoverHeroi(int id) 
        {
            if (id < 0)
            {
                throw new BadRequestException("Identificação inváldia. Por favor, coloque um ID válido");
            }
            try
            {
                Herois heroi = await _heroiRepository.ObterHeroiPeloId(id);
                if (heroi == null)
                {
                    throw new NotFoundException("Identificação não encontrada. Por favor, coloque um ID existente;");
                }

                await _heroiRepository.RemoverHeroi(heroi);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
