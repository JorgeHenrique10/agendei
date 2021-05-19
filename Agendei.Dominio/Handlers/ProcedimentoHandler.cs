using Agendei.Dominio.Commands.ProcedimentoCommand.Entradas;
using Agendei.Dominio.Commands.ProcedimentoCommand.Saidas;
using Agendei.Dominio.Commands.ContractCommands;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;

namespace Agendei.Dominio.Handlers
{
    public class ProcedimentoHandler : ICommandHandler<CriarProcedimentoCommand>, ICommandHandler<EditarProcedimentoCommand>, ICommandHandler<DeletarProcedimentoCommand>
    {
        public readonly IProcedimentoRepository _procedimentoRepository;
        public ProcedimentoHandler(IProcedimentoRepository ProcedimentoRepository)
        {
            _procedimentoRepository = ProcedimentoRepository;
        }
        public ICommandResult Handle(CriarProcedimentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoProcedimentoCommandResult(false, "Ops Algo errado no seu Command", command.Notifications);

            var Procedimento = new Procedimento(command.Nome, command.Descricao, command.Valor);

            _procedimentoRepository.Salvar(Procedimento);

            return new GenericoProcedimentoCommandResult(true, "Procedimento criado com sucesso!", Procedimento);
        }

        public ICommandResult Handle(EditarProcedimentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoProcedimentoCommandResult(false, "Ops Algo errado no seu Command", command.Notifications);

            var Procedimento = _procedimentoRepository.BuscarProcedimentoId(command.Id);

            if (Procedimento == null)
                return new GenericoProcedimentoCommandResult(false, "Procedimento não encontrado", command.Notifications);

            Procedimento.AlterarNome(command.Nome);
            Procedimento.AlterarDescricao(command.Descricao);
            Procedimento.AlterarValor(command.Valor);

            _procedimentoRepository.Editar(command);

            return new GenericoProcedimentoCommandResult(true, "Procedimento Editado com sucesso!", Procedimento);
        }

        public ICommandResult Handle(DeletarProcedimentoCommand command)
        {
            if (!command.Valid())
                return new GenericoProcedimentoCommandResult(false, "Ops parece que o Procedimento que quer deletar possui algum erro!", command.Notifications);

            if (_procedimentoRepository.BuscarProcedimentoId(command.Id) == null)
                return new GenericoProcedimentoCommandResult(false, "Procedimento não encontrado", command.Notifications);

            _procedimentoRepository.Deletar(command.Id);

            return new GenericoProcedimentoCommandResult(true, "Procedimento Deletado com sucesso!", command.Nome);
        }
    }
}