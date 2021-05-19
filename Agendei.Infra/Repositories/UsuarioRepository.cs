using System;
using System.Collections.Generic;
using System.Linq;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;
using Agendei.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agendei.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AgendeiContext _context;
        public UsuarioRepository(AgendeiContext context)
        {
            _context = context;
        }
        public Usuario BuscarUsuarioId(Guid id)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> BuscarTodosUsuarios()
        {
            return _context.Usuarios.AsNoTracking().ToList();
        }

        public void Deletar(Guid id)
        {
            var Objeto = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            _context.Usuarios.Remove(Objeto);
            _context.SaveChanges();
        }

        public void Editar(object Usuario)
        {
            _context.Entry(Usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Salvar(Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
        }

        public Usuario Login(string login, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login == login && x.Senha == senha);
        }
    }
}