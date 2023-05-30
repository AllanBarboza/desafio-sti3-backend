using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Data.Repositories
{
    public interface IClienteRepository
    {
        public Task Create(Cliente cliente);
        public Task Update(Cliente cliente);
        public Task Delete(Cliente cliente);
        public Task<List<Cliente>> Get();
        public Task<Cliente> GetById(Guid id);
    }
    public class ClienteRepository : IClienteRepository
    {
        private AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> Get()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            return await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}