using System;
using System.Collections.Generic;
using Agendei.Dominio.Commands.ContractCommands;
using Agendei.Dominio.Entities;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.AgendamentoCommand.Entradas
{
    public class CriarAgendamentoCommand : Notifiable, ICommand
    {
        public CriarAgendamentoCommand(Guid clienteId, List<Procedimento> procedimentos, string observacao)
        {
            ClienteId = clienteId;
            Observacao = observacao;
            Procedimentos = procedimentos;
        }

        public Guid ClienteId { get; set; }
        public List<Procedimento> Procedimentos { get; set; }
        public string Observacao { get; set; }

        public bool Valid()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasLen(ClienteId.ToString(), 36, "Cliente", "Identificador do cliente inválido")
            );

            return IsValid;
        }
    }
}