using System;
using System.Collections.Generic;
using Agendei.Dominio.Entities;

namespace Agendei.Dominio.Repositories
{
    public interface IClienteRepository
    {
        void Salvar(Cliente cliente);
        void Editar(object cliente);
        void Deletar(Guid id);
        List<Cliente> BuscarTodosClientes();
        Cliente BuscarClienteId(Guid id);
    }
}