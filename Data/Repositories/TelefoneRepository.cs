using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Data.Repositories
{
    public interface ITelefoneRepository
    {
        public Task Create(ClienteTelefone telefone);
        public Task Update(ClienteTelefone telefone);
        public Task Delete(ClienteTelefone telefone);
        public Task<List<ClienteTelefone>> Get(Guid ClienteId);
        public Task<ClienteTelefone> GetById(Guid id);
    }
    public class TelefoneRepository : ITelefoneRepository
    {
        private AppDbContext _context;
        public TelefoneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ClienteTelefone telefone)
        {
            await _context.ClienteTelefone.AddAsync(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ClienteTelefone telefone)
        {
            _context.ClienteTelefone.Remove(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteTelefone>> Get(Guid ClienteId)
        {
            return await _context.ClienteTelefone.Where(ct => ct.ClienteId.Equals(ClienteId)).AsNoTracking().ToListAsync();
        }

        public async Task<ClienteTelefone> GetById(Guid id)
        {
            return await _context.ClienteTelefone.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(ClienteTelefone telefone)
        {
            _context.ClienteTelefone.Update(telefone);
            await _context.SaveChangesAsync();
        }
    }
}