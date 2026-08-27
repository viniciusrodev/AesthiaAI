using AesthiaAI.Domain.Entities;
using AesthiaAI.Domain.Interfaces;
using AesthiaAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AesthiaAI.Infrastructure.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AppDbContext _context;

        public AgendaRepository(AppDbContext context)
        {

            _context = context;
        }
        public async Task<List<AgendaServico>> BuscarPorEsteticistaEDataAsync(Guid esteticistaId, DateTime data)
        {
            return await _context.AgendaServicos
                .Where(x =>
                x.Esteticista.Id == esteticistaId &&
                x.DataAgendamento.Date == data.Date)
                .ToListAsync();
        }

        public async Task AdicionarAsync(AgendaServico agenda)
        {
            await _context.AgendaServicos.AddAsync(agenda);
            await _context.SaveChangesAsync();
        }
      
    }
}
