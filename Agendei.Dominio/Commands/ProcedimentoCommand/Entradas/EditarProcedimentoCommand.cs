using System;
using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.ProcedimentoCommand.Entradas
{
    public class EditarProcedimentoCommand : Notifiable, ICommand
    {
        public EditarProcedimentoCommand()
        {

        }

        public EditarProcedimentoCommand(Guid id, string nome, string descricao, double valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }


        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNullOrEmpty(Id.ToString(), "Id", "O campo não pode ser nulo")
                .IsNullOrEmpty(Nome, "Nome", "O campo não pode ser nulo")
                .IsNull(Valor, "Valor", "O campo deve ser nulo!")
            );

            return IsValid;
        }
    }
}