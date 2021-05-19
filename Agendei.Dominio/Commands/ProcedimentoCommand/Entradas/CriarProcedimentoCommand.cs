using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.ProcedimentoCommand.Entradas
{
    public class CriarProcedimentoCommand : Notifiable, ICommand
    {
        public CriarProcedimentoCommand()
        {

        }

        public CriarProcedimentoCommand(string nome, string descricao, double valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }


        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O campo não pode ser nulo")
            );

            return IsValid;
        }
    }
}