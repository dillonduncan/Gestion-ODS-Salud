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
    public class IndicadorSaludRepository : IGenericRepository<IndicadorSalud>
    {
        private readonly GestionOdsSaludContext _context;
        public IndicadorSaludRepository(GestionOdsSaludContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                IndicadorSalud indsalud=_context.IndicadorSaluds.First(ids=>ids.IdIndicador.ToString()==id);
                _context.Remove(indsalud);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<IQueryable<IndicadorSalud>> GetAll()
        {
            try
            {
                IQueryable<IndicadorSalud> queryIndicador = _context.IndicadorSaluds.Include(idm => idm.IdMetaNavigation);
                return queryIndicador;
            }
            catch { return null; }
        }

        public async Task<IndicadorSalud> GetID(string id)
        {
            try
            {
                return await _context.IndicadorSaluds.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(IndicadorSalud model)
        {
            try
            {
                _context.IndicadorSaluds.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(IndicadorSalud model)
        {
            try
            {
                _context.IndicadorSaluds.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
