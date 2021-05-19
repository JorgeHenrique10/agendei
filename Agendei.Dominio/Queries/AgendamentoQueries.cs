using System;
using System.Linq.Expressions;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Enuns;

namespace Agendei.Dominio.Queries
{
    public static class AgendamentoQueries
    {
        public static Expression<Func<Agendamento, bool>> BuscarAgendamentoId(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamento()
        {
            return (x => x.Id.ToString() != "");
        }
        public static Expression<Func<Agendamento, bool>> ListarAgendamentosPorCliente(Guid clienteId)
        {
            return x => x.ClienteId == clienteId;
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return x => x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date;
        }
        public static Expression<Func<Agendamento, bool>> ListarAgendamentosData(DateTime data)
        {
            return x => x.DataAgendamento.Date == data.Date;
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorPeriodoCliente(DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return x => x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date && x.ClienteId == clienteId;
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorStatusAgendamento(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim)
        {
            return x => x.StatusAgendamento == agendamentostatus
                     && (x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date);
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorStatusPagamento(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim)
        {
            return x => x.StatusPagamento == pagamentostatus
                     && (x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date);
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorStatusAgendamentoPorCliente(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return x => x.StatusAgendamento == agendamentostatus
                     && x.ClienteId == clienteId
                     && (x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date);
        }
        public static Expression<Func<Agendamento, bool>> ListarTodosAgendamentosPorStatusPagamentoPorCliente(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return x => x.StatusPagamento == pagamentostatus
                     && x.ClienteId == clienteId
                     && (x.DataAgendamento.Date >= dataInicio.Date && x.DataAgendamento <= dataFim.Date);
        }

    }
}