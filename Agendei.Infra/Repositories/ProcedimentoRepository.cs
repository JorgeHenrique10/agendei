using System;
using System.Collections.Generic;
using System.Linq;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;
using Agendei.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agendei.Infra.Repositories
{
    public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly AgendeiContext _context;
        public ProcedimentoRepository(AgendeiContext context)
        {
            _context = context;
        }
        public Procedimento BuscarProcedimentoId(Guid id)
        {
            return _context.Procedimentos.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Procedimento> BuscarTodosProcedimentos()
        {
            return _context.Procedimentos.AsNoTracking().ToList();
        }

        public void Deletar(Guid id)
        {
            var Objeto = _context.Procedimentos.FirstOrDefault(x => x.Id == id);
            _context.Procedimentos.Remove(Objeto);
            _context.SaveChanges();
        }

        public void Editar(object procedimento)
        {
            _context.Entry(procedimento).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Salvar(Procedimento procedimento)
        {
            _context.Procedimentos.Add(procedimento);
            _context.SaveChanges();
        }
    }
}