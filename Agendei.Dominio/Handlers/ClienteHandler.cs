using Agendei.Dominio.Commands.ClienteCommand.Entradas;
using Agendei.Dominio.Commands.ClienteCommand.Saidas;
using Agendei.Dominio.Commands.ContractCommands;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;

namespace Agendei.Dominio.Handlers
{
    public class ClienteHandler : ICommandHandler<CriarClienteCommand>, ICommandHandler<EditarClienteCommand>, ICommandHandler<DeletarClienteCommand>
    {
        public readonly IClienteRepository _clienteRepository;
        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ICommandResult Handle(CriarClienteCommand command)
        {
            if (command.Valid() == false)
                return new GenericoClienteCommandResult(false, "Ops Algo errado no seu Command", command.Notifications);

            var Cliente = new Cliente(command.PrimeiroNome, command.UltimoNome, command.Telefone, command.Email);

            _clienteRepository.Salvar(Cliente);

            return new GenericoClienteCommandResult(true, "Cliente Salvo com sucesso!", Cliente);
        }

        public ICommandResult Handle(EditarClienteCommand command)
        {
            if (command.Valid() == false)
                return new GenericoClienteCommandResult(false, "Ops Algo errado no seu Command", command.Notifications);

            var Cliente = _clienteRepository.BuscarClienteId(command.Id);

            if (Cliente == null)
                return new GenericoClienteCommandResult(false, "Cliente não encontrado", command.Notifications);

            Cliente.AlterarNome(command.PrimeiroNome, command.UltimoNome);
            Cliente.AlterarTelefone(command.Telefone);
            Cliente.AlterarEmail(command.Email);

            _clienteRepository.Editar(command);

            return new GenericoClienteCommandResult(true, "Cliente Editado com sucesso!", Cliente);
        }

        public ICommandResult Handle(DeletarClienteCommand command)
        {
            if (!command.Valid())
                return new GenericoClienteCommandResult(false, "Ops parece que o Cliente que quer deletar possui algum erro!", command.Notifications);

            if (_clienteRepository.BuscarClienteId(command.Id) == null)
                return new GenericoClienteCommandResult(false, "Cliente não encontrado", command.Notifications);

            _clienteRepository.Deletar(command.Id);

            return new GenericoClienteCommandResult(true, "Cliente Deletado com sucesso!", command.Id);
        }
    }
}