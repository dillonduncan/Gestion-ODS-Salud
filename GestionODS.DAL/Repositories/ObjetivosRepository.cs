using GestionODS.DAL.DataContext;
using GestionODS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionODS.DAL.Repositories
{
    public class ObjetivosRepository : IGenericRepository<ObjetivoOd>
    {
        private readonly GestionOdsSaludContext _context;
        public ObjetivosRepository(GestionOdsSaludContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                ObjetivoOd obje = _context.ObjetivoOds.First(o => o.IdObjetivo.ToString() == id);
                _context.Remove(obje);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<IQueryable<ObjetivoOd>> GetAll()
        {
            try
            {
                IQueryable<ObjetivoOd> queryObj = _context.ObjetivoOds;
                return queryObj;
            }
            catch { return null; }
        }

        public async Task<ObjetivoOd> GetID(string id)
        {
            try
            {
                return await _context.ObjetivoOds.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(ObjetivoOd model)
        {
            try
            {
                _context.ObjetivoOds.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(ObjetivoOd model)
        {
            try
            {
                _context.ObjetivoOds.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
