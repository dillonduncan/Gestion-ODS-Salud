using GestionODS.DAL.DataContext;
using GestionODS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionODS.DAL.Repositories
{
    public class DatoIndicadorRepository : IGenericRepository<DatoIndicador>
    {
        private readonly GestionOdsSaludContext _context;
        public DatoIndicadorRepository(GestionOdsSaludContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                DatoIndicador datoInd = _context.DatoIndicadors.First(di => di.IdIndicador.ToString() == id);
                _context.Remove(datoInd);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<IQueryable<DatoIndicador>> GetAll()
        {
            try
            {
                IQueryable<DatoIndicador>queryIndicador=_context.DatoIndicadors.Include(ind=>ind.IdIndicadorNavigation).Include(pa=>pa.IdPaisNavigation).Include(re=>re.IdRegionNavigation).Include(idf=>idf.IdFuenteNavigation);
                return queryIndicador;
            }
            catch { return null; }
        }

        public async Task<DatoIndicador> GetID(string id)
        {
            try
            {
                return await _context.DatoIndicadors.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(DatoIndicador model)
        {
            try
            {
                _context.DatoIndicadors.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(DatoIndicador model)
        {
            try
            {
                _context.DatoIndicadors.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
