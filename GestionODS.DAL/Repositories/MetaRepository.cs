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
    public class MetaRepository:IGenericRepository<MetaOd>
    {
        private GestionOdsSaludContext _context;
        public MetaRepository(GestionOdsSaludContext context)
        {
            _context=context;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                MetaOd meta = _context.MetaOds.First(m => m.IdMeta.ToString() == id);
                _context.Remove(meta);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<IQueryable<MetaOd>> GetAll()
        {
            try
            {
                IQueryable<MetaOd> querymeta = _context.MetaOds.Include(o => o.IdObjetivoNavigation);
                return querymeta;
            }
            catch { return null; }
        }

        public async Task<MetaOd> GetID(string id)
        {
            try
            {
                return await _context.MetaOds.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(MetaOd model)
        {
            try
            {
                _context.MetaOds.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(MetaOd model)
        {
            try
            {
                _context.MetaOds.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false;  }
        }
    }
}
