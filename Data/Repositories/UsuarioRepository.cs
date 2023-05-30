using System.Threading.Tasks;
using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Data.Repositories
{

    public interface IUsuarioRepository
    {
        public Task Create(Usuario usuario);
        public Task<Usuario> GetByCredentials(string email, string password);
        public Task<Usuario> GetByEmail(string email);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetByCredentials(string email, string password)
        {
            return await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}