using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Agendei.Dominio.Commands.AgendamentoCommand.Entradas;
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
    [Route("v1/agendamentos")]
    public class AgendamentoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public GenericoAgendamentoCommandResult ListarAGendamentos([FromServices] IAgendamentoRepository repository)
        {
            var agendamentos = repository.ListarTodosAgendamento();
            return new GenericoAgendamentoCommandResult(true, "Sucesso", (agendamentos));
        }

        [Route("{id}")]
        [HttpGet]
        public GenericoAgendamentoCommandResult ListarAGendamentosPorCliente([FromServices] IAgendamentoRepository repository, Guid id)
        {
            var agendamento = repository.ListarAgendamentosPorCliente(id);
            return new GenericoAgendamentoCommandResult(true, "Sucesso", (agendamento));
        }

        [Route("")]
        [HttpPost]
        public GenericoAgendamentoCommandResult CriarAGendamento([FromBody] CriarAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/atender")]
        [HttpPut]
        public GenericoAgendamentoCommandResult AtenderAGendamento([FromBody] AtenderAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/cancelar")]
        [HttpPut]
        public GenericoAgendamentoCommandResult CancelarAGendamento([FromBody] CancelarAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/finalizar")]
        [HttpPut]
        public GenericoAgendamentoCommandResult FinalizarAGendamento([FromBody] FinalizarAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/pagamentos/pagar")]
        [HttpPut]
        public GenericoAgendamentoCommandResult PagarPagamentoAgendamento([FromBody] PagarPagamentoAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/pagamentos/cancelar")]
        [HttpPut]
        public GenericoAgendamentoCommandResult CancelarPagamentoAgendamento([FromBody] CancelarPagamentoAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }

        [Route("/pagamentos/pendente")]
        [HttpPut]
        public GenericoAgendamentoCommandResult PendentePagamentoAgendamento([FromBody] PendentePagamentoAgendamentoCommand command, [FromServices] AgendamentoHandler handler)
        {
            return (GenericoAgendamentoCommandResult)handler.Handle(command);
        }
    }
}