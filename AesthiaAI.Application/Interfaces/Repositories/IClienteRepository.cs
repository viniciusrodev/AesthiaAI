using AesthiaAI.Domain.Entities;

namespace AesthiaAI.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {

        Task AdicionarAsync(Cliente cliente);

        Task<Cliente?> ObterPorIdAsync(Guid ID);
    }
}
