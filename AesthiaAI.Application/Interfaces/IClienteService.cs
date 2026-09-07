using AesthiaAI.Application.DTOs.Clientes;

namespace AesthiaAI.Application.Interfaces
{
    public interface IClienteService
    {

        Task<Guid> CriarAsync(CriarClienteRequest request); 
    }
}
