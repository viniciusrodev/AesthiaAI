using AesthiaAI.Application.DTOs.Clientes;
using AesthiaAI.Application.Interfaces;
using AesthiaAI.Application.Interfaces.Repositories;
using AesthiaAI.Domain.Entities;
using AesthiaAI.Domain.ValueObjects;


namespace AesthiaAI.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {

            _clienteRepository = clienteRepository; 
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> CriarAsync(CriarClienteRequest request)
        {
            var cpf = new Cpf(request.Cpf);
            var email = new Email(request.Email);
            var telefone = new Telefone(request.Telefone);


            var endereco = new Endereco(
                request.Cep,
                request.Estado,
                request.Cidade,
                request.Bairro,
                request.Rua,
                request.Numero,
                request.Complemento
                );

            var cliente = new Cliente(
                request.Nome,
                request.Sobrenome,
                cpf,
                email,
                telefone,
                endereco
                );

            await _clienteRepository.AdicionarAsync(cliente);
            await _unitOfWork.SaveChangesAsync();

            return cliente.Id;
        }
    }
}
