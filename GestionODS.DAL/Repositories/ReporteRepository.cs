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
    public class ReporteRepository : IGenericRepository<Reporte>
    {
        private readonly GestionOdsSaludContext _context;
        public ReporteRepository(GestionOdsSaludContext context)
        {
            _context=context;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                Reporte report = _context.Reportes.First(r => r.IdReporte.ToString() == id);
                _context.Remove(report);
                await _context.SaveChangesAsync();
                return true;
            }
            catch{ return false; }
        }

        public async Task<IQueryable<Reporte>> GetAll()
        {
            try
            {
                IQueryable<Reporte> queryReport = _context.Reportes.Include(us=>us.IdUsuarioNavigation);
                return queryReport;
            }
            catch { return null; }
        }

        public async Task<Reporte> GetID(string id)
        {
            try
            {
                return await _context.Reportes.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(Reporte model)
        {
            try
            {
                _context.Reportes.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(Reporte model)
        {
            try
            {
                _context.Reportes.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
