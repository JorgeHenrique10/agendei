namespace Agendei.Dominio.Commands.ContractCommands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}