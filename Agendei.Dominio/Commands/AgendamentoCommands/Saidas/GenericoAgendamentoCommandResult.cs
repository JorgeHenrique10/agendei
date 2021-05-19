using Agendei.Dominio.Commands.ContractCommands;

namespace Agendei.Dominio.Commands.AgendamentoCommand.Saidas
{
    public class GenericoAgendamentoCommandResult : ICommandResult
    {
        public GenericoAgendamentoCommandResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}