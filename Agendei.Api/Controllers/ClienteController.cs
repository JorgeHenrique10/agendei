using System;
using System.Collections.Generic;
using Agendei.Dominio.Commands.AgendamentoCommand.Saidas;
using Agendei.Dominio.Commands.ClienteCommand.Entradas;
using Agendei.Dominio.Commands.ClienteCommand.Saidas;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Handlers;
using Agendei.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agendei.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Cliente> BuscarTodosClientes([FromServices] IClienteRepository repository)
        {
            return repository.BuscarTodosClientes();
        }

        [Route("/{id}")]
        [HttpGet]
        public Cliente BuscarClienteId([FromServices] IClienteRepository repository, Guid id)
        {
            return repository.BuscarClienteId(id);
        }

        [Route("")]
        [HttpPost]
        public GenericoClienteCommandResult Criar([FromBody] CriarClienteCommand command, [FromServices] ClienteHandler handler)
        {
            return (GenericoClienteCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericoClienteCommandResult Editar([FromBody] EditarClienteCommand command, [FromServices] ClienteHandler handler)
        {
            return (GenericoClienteCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericoClienteCommandResult Deletar([FromBody] DeletarClienteCommand command, [FromServices] ClienteHandler handler)
        {
            return (GenericoClienteCommandResult)handler.Handle(command);
        }
    }
}