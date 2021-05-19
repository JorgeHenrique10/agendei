using System;
using System.Collections.Generic;
using System.Linq;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;
using Agendei.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agendei.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AgendeiContext _context;
        public ClienteRepository(AgendeiContext context)
        {
            _context = context;
        }
        public Cliente BuscarClienteId(Guid id)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> BuscarTodosClientes()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        public void Deletar(Guid id)
        {
            var Objeto = _context.Clientes.FirstOrDefault(x => x.Id == id);
            _context.Clientes.Remove(Objeto);
            _context.SaveChanges();
        }

        public void Editar(object Cliente)
        {
            _context.Entry(Cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Salvar(Cliente Cliente)
        {
            _context.Clientes.Add(Cliente);
            _context.SaveChanges();
        }
    }
}