using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace CGAP_API.Repository.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public ApplicationDbContext context;
        public UserManager<Usuario> _userManager;
        public SignInManager<Usuario> _signInManager;

        public UsuariosRepository(ApplicationDbContext _context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            context = _context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Add(Usuario item)
        {
            await _userManager.CreateAsync(item);
        }

        public async Task<Usuario> Find(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios.ToList();
        }

        public async Task Remove(string Id)
        {
            await _userManager.DeleteAsync(await Find(Id));
        }

        public async Task Update(Usuario itemToUpdate, Usuario item)
        {
            await _userManager.UpdateAsync(item);
        }
    }
}
