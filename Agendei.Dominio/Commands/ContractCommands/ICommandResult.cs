namespace Agendei.Dominio.Commands.ContractCommands
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }
    }
}