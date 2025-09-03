using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SuperHeroi.Domain.Entities;
using System.Threading.Tasks;
using SuperHeroi.Infra.Context;
using SuperHeroi.Infra.Interfaces;

namespace SuperHeroi.Infra.Repositories
{
    public class SuperPoderesRepository : ISuperPoderesRepository
    {
        private readonly SuperHeroDBContext _context;
        public SuperPoderesRepository(SuperHeroDBContext context) => _context = context;


        public async Task<List<Superpoderes>> ObterTodosSuperPoderes() 
        {
            return await _context.Superpoderes.ToListAsync();
        } 

        public async Task<Superpoderes> RegistrarSuperPoder(Superpoderes superpoder)
        {
            _context.Add(superpoder);
            await _context.SaveChangesAsync();
            return superpoder;
        }
        public async Task<Superpoderes> ObterSuperPoderPeloId(int id) 
        { 
            return await _context.Superpoderes.FirstOrDefaultAsync(x => x.Id == id);
        } 

        public async Task<Superpoderes> ObterSuperPoderPeloNome(string nomeSuperPoder) 
        {
           return await _context.Superpoderes.FirstOrDefaultAsync(x => x.Superpoder == nomeSuperPoder);
        } 

    }
}
