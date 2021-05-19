using System;
using System.Collections.Generic;
using Agendei.Dominio.Entities;

namespace Agendei.Dominio.Repositories
{
    public interface IUsuarioRepository
    {
        void Salvar(Usuario usuario);
        void Editar(object usuario);
        void Deletar(Guid id);
        List<Usuario> BuscarTodosUsuarios();
        Usuario BuscarUsuarioId(Guid Id);
        Usuario Login(string login, string senha);
    }
}