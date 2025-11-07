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
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        private readonly GestionOdsSaludContext _context;
        public UsuarioRepository(GestionOdsSaludContext context)
        {
            _context= context;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                Usuario user = _context.Usuarios.First(u => u.IdUsuario.ToString() == id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<IQueryable<Usuario>> GetAll()
        {
            try
            {
                IQueryable<Usuario> queryUser = _context.Usuarios;
                return queryUser;
            }
            catch { return null; }
        }

        public async Task<Usuario> GetID(string id)
        {
            try
            {
                return await _context.Usuarios.FindAsync(id);
            }
            catch { return null; }
        }

        public async Task<bool> Insert(Usuario model)
        {
            try
            {
                _context.Usuarios.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(Usuario model)
        {
            try
            {
                _context.Usuarios.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
