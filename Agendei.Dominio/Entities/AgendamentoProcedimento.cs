using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Agendei.Dominio.Enuns;

namespace Agendei.Dominio.Entities
{
    public class AgendamentoProcedimento : Entidade
    {
        public Procedimento Procedimento { get; set; }
        public List<Procedimento> procedimentos { get; set; }
        public Agendamento Agendemento { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}