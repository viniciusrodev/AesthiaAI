using AesthiaAI.Application.Interfaces.Repositories;
using AesthiaAI.Domain.Entities;
using AesthiaAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AesthiaAI.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {

            _context = context;
        }
        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
         
        }

        public async Task<Cliente?> ObterPorIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);

        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {

            return await _context.Clientes.ToListAsync();

        }

        public void Remover(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);

        }
    }
}   
