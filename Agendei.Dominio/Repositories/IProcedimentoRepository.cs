using System;
using System.Collections.Generic;
using Agendei.Dominio.Entities;

namespace Agendei.Dominio.Repositories
{
    public interface IProcedimentoRepository
    {
        void Salvar(Procedimento procedimento);
        void Editar(object procedimento);
        void Deletar(Guid id);
        List<Procedimento> BuscarTodosProcedimentos();
        Procedimento BuscarProcedimentoId(Guid Id);
    }
}