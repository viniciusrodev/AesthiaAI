using AesthiaAI.Domain.Entities;


namespace AesthiaAI.Domain.Interfaces

   {
    public interface IAgendaRepository
    {
        Task<List<AgendaServico>> BuscarPorEsteticistaEDataAsync(
            Guid esteticistaId,
            DateTime data);

        Task AdicionarAsync(AgendaServico agenda);
    }
}

