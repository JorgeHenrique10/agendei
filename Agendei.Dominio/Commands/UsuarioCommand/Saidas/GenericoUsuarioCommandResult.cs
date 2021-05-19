using Agendei.Dominio.Commands.ContractCommands;

namespace Agendei.Dominio.Commands.UsuarioCommand.Saidas
{
    public class GenericoUsuarioCommandResult : ICommandResult
    {
        public GenericoUsuarioCommandResult(bool sucesso, string mensagem, object data)
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