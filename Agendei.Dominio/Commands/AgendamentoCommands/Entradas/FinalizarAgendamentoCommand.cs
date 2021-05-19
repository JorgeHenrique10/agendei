using System;
using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.AgendamentoCommand.Entradas
{
    public class FinalizarAgendamentoCommand : Notifiable, ICommand
    {
        public FinalizarAgendamentoCommand()
        {

        }
        public FinalizarAgendamentoCommand(Guid id, string observacao)
        {
            Id = id;
            Observacao = observacao;
        }

        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public bool Valid()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasLen(Id.ToString(), 36, "Id", "Favor passar um Id válido!")
            );

            return IsValid;
        }
    }
}