using System;
using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.ClienteCommand.Entradas
{
    public class DeletarClienteCommand : Notifiable, ICommand
    {
        public DeletarClienteCommand()
        {

        }

        public DeletarClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id", "O campo não pode ser nulo")
            );

            return IsValid;
        }
    }
}