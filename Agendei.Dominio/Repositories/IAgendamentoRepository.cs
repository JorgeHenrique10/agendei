using System;
using System.Collections.Generic;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Enuns;

namespace Agendei.Dominio.Repositories
{
    public interface IAgendamentoRepository
    {
        void Salvar(Agendamento agendamento);
        void Editar(Agendamento agendamento);
        void Deletar(Guid id);

        IEnumerable<Agendamento> ListarTodosAgendamento();
        IEnumerable<Agendamento> ListarAgendamentosPorCliente(Guid clienteId);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorPeriodoCliente(DateTime dataInicio, DateTime dataFim, Guid clienteId);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusAgendamento(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusPagamento(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusAgendamentoPorCliente(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId);
        IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusPagamentoPorCliente(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId);
        Agendamento BuscarAgendamentoId(Guid Id);
        IEnumerable<Agendamento> ListarAgendamentoData(DateTime dataAgendamento);



    }
}