using System;
using System.Collections.Generic;
using Agendei.Dominio.Commands.AgendamentoCommand.Saidas;
using Agendei.Dominio.Commands.ProcedimentoCommand.Entradas;
using Agendei.Dominio.Commands.ProcedimentoCommand.Saidas;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Handlers;
using Agendei.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agendei.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/procedimentos")]
    public class ProcedimentoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Procedimento> BuscarTodosProcedimentos([FromServices] IProcedimentoRepository repository)
        {
            return repository.BuscarTodosProcedimentos();
        }

        [Route("/{id}")]
        [HttpGet]
        public Procedimento BuscarProcedimentoId([FromServices] IProcedimentoRepository repository, Guid id)
        {
            return repository.BuscarProcedimentoId(id);
        }

        [Route("")]
        [HttpPost]
        public GenericoProcedimentoCommandResult Criar([FromBody] CriarProcedimentoCommand command, [FromServices] ProcedimentoHandler handler)
        {
            return (GenericoProcedimentoCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericoProcedimentoCommandResult Editar([FromBody] EditarProcedimentoCommand command, [FromServices] ProcedimentoHandler handler)
        {
            return (GenericoProcedimentoCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericoProcedimentoCommandResult Deletar([FromBody] DeletarProcedimentoCommand command, [FromServices] ProcedimentoHandler handler)
        {
            return (GenericoProcedimentoCommandResult)handler.Handle(command);
        }
    }
}