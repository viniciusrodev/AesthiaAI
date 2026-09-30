using AesthiaAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AesthiaAI.Application.DTOs.Clientes
{
   public class AtualizarClienteRequest
    {

    
            public string Nome { get; set; } = string.Empty;

            public string Sobrenome { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public string Telefone { get; set; } = string.Empty;

            public string Cep { get; set; } = string.Empty;

            public string Estado { get; set; } = string.Empty;

            public string Cidade { get; set; } = string.Empty;

            public string Bairro { get; set; } = string.Empty;

            public string Rua { get; set; } = string.Empty;

            public string Numero { get; set; } = string.Empty;

            public string? Complemento { get; set; }


             
        }
    }



