using AesthiaAI.Application.Interfaces.Repositories;
using AesthiaAI.Domain.Entities;
using AesthiaAI.Infrastructure.Data;

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
    }
}   
