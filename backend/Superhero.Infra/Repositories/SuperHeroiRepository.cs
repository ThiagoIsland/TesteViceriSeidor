using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperHeroi.Domain.Entities;
using SuperHeroi.Infra.Context;
using SuperHeroi.Infra.Interfaces;

namespace SuperHeroi.Infra.Repositories
{
    public class SuperHeroiRepository : ISuperHeroiRepository
    {
        private readonly SuperHeroDBContext _context;
        public SuperHeroiRepository(SuperHeroDBContext context) => _context = context;
        public async Task<Herois> RegistrarSuperHeroi(Herois heroi)
        {
            await _context.Herois.AddAsync(heroi);
            await _context.SaveChangesAsync();
            return heroi;
        }
        public async Task<List<Herois>> ObterTodosHerois()
        {
            return await _context.Herois.ToListAsync();
        }
        public async Task<Herois> ObterHeroiPeloId(int id)
        {
            return await _context.Herois.FindAsync(id);
        }
        public async Task<Herois> ObterHeroiPeloNome(string nome)
        {
            return await _context.Herois.FirstOrDefaultAsync(heroi => heroi.Nome == nome);
        }
        //public async Task<Herois> AtualizarHeroiPeloId(int Id)
        //{
        //    return _context.Herois.FindAsync();
        //}
        public async Task RemoverHeroi(Herois heroi)
        {
            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
        }
    }
}
