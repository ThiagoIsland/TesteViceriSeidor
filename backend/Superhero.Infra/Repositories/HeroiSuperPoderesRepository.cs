using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SuperHeroi.Infra.Context;
using SuperHeroi.Domain.Entities;
using System.Linq;
using SuperHeroi.Infra.Interfaces;

namespace SuperHeroi.Infra.Repositories
{
    public class HeroiSuperPoderesRepository : IHeroiSuperPoderesRepository
    {
        private readonly SuperHeroDBContext _context;
        public HeroiSuperPoderesRepository(SuperHeroDBContext context) => _context = context;
        public async Task AdicionarPoderesSuperHeroiPeloId(List<HeroisSuperpoderes> heroisSuperpoderes)
        {
            await _context.HeroisSuperpoderes.AddRangeAsync(heroisSuperpoderes);
            await _context.SaveChangesAsync();
        }
        public async Task<List<HeroisSuperpoderes>> ObterPoderesSuperHeroiPeloId(int heroiId)
        {
            return await _context.HeroisSuperpoderes.Where(hp => hp.HeroiId == heroiId).ToListAsync();
        }
        public async Task RemoverPoderesSuperHeroiPeloId(List<HeroisSuperpoderes> heroisSuperpoderes)
        {
            _context.HeroisSuperpoderes.RemoveRange(heroisSuperpoderes);
            await _context.SaveChangesAsync();

        }
    }
}
