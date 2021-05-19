using System;
using System.Collections.Generic;
using System.Linq;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Enuns;
using Agendei.Dominio.Queries;
using Agendei.Dominio.Repositories;
using Agendei.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agendei.Infra.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AgendeiContext _context;
        public AgendamentoRepository(AgendeiContext context)
        {
            _context = context;
        }
        public Agendamento BuscarAgendamentoId(Guid id)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Deletar(Guid id)
        {
            var Objeto = _context.Agendamentos.Include(x => x.Procedimentos).Where(AgendamentoQueries.BuscarAgendamentoId(id)).FirstOrDefault();
            _context.Agendamentos.Remove(Objeto);
            _context.SaveChangesAsync();
        }

        public void Editar(Agendamento agendamento)
        {
            _context.Entry(agendamento).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Agendamento> ListarAgendamentoData(DateTime dataAgendamento)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarAgendamentosData(dataAgendamento))
            .OrderBy(x => x.DataAgendamento);
        }

        public IEnumerable<Agendamento> ListarAgendamentosPorCliente(Guid clienteId)
        {
            return _context.Agendamentos.AsNoTracking()
            .Where(AgendamentoQueries.ListarAgendamentosPorCliente(clienteId)).Include(x => x.Procedimentos);
            // return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            //                             .Where(x => x.ClienteId == clienteId).ToList();
        }

        public IEnumerable<Agendamento> ListarTodosAgendamento()
        {
            return _context.Agendamentos.Include(a => a.Procedimentos).AsNoTracking().ToList();
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorPeriodo(dataInicio, dataFim));
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorPeriodoCliente(DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorPeriodoCliente(dataInicio, dataFim, clienteId));
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusAgendamento(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorStatusAgendamento(agendamentostatus, dataInicio, dataFim));
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusAgendamentoPorCliente(EAgendamentoStatus agendamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorStatusAgendamentoPorCliente(agendamentostatus, dataInicio, dataFim, clienteId));
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusPagamento(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorStatusPagamento(pagamentostatus, dataInicio, dataFim));
        }

        public IEnumerable<Agendamento> ListarTodosAgendamentosPorStatusPagamentoPorCliente(EPagamentoStatus pagamentostatus, DateTime dataInicio, DateTime dataFim, Guid clienteId)
        {
            return _context.Agendamentos.Include(x => x.Procedimentos).AsNoTracking()
            .Where(AgendamentoQueries.ListarTodosAgendamentosPorStatusPagamentoPorCliente(pagamentostatus, dataInicio, dataFim, clienteId));
        }

        public void Salvar(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }
    }
}