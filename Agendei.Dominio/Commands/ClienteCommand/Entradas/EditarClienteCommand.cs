using System;
using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.ClienteCommand.Entradas
{
    public class EditarClienteCommand : Notifiable, ICommand
    {
        public EditarClienteCommand()
        {

        }

        public EditarClienteCommand(Guid Id, string primeiroNome, string ultimoNome, string telefone, string email)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Telefone = telefone;
            Email = email;
        }

        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Id.ToString(), "Id", "O campo não pode ser nulo")
                .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O campo deve conter no mínimo 3 caracteres")
                .HasMinLen(UltimoNome, 3, "UltimoNome", "O campo deve conter no mínimo 3 caracteres")
                .HasMinLen(Telefone, 10, "Telefone", "O campo deve conter de 10 a 11 caracteres")
                .HasMaxLen(Telefone, 11, "Telefone", "O campo deve conter de 10 a 11 caracteres")
                .IsEmail(Email, "Email", "O campo email está inválido")
            );

            return IsValid;
        }
    }
}