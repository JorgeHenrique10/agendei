using System;
using Agendei.Dominio.Commands.AgendamentoCommand.Entradas;
using Agendei.Dominio.Commands.AgendamentoCommand.Saidas;
using Agendei.Dominio.Commands.ContractCommands;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;

namespace Agendei.Dominio.Handlers
{
    public class AgendamentoHandler : ICommandHandler<AtenderAgendamentoCommand>,
                    ICommandHandler<CancelarAgendamentoCommand>, ICommandHandler<CancelarPagamentoAgendamentoCommand>,
                    ICommandHandler<CriarAgendamentoCommand>, ICommandHandler<FinalizarAgendamentoCommand>,
                    ICommandHandler<PagarPagamentoAgendamentoCommand>, ICommandHandler<PendentePagamentoAgendamentoCommand>
    {
        protected readonly IAgendamentoRepository _agendamentoRepository;
        protected readonly IClienteRepository _clienteRepository;
        public AgendamentoHandler(IAgendamentoRepository agendamentoRepository, IClienteRepository clienteRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _clienteRepository = clienteRepository;
        }
        public ICommandResult Handle(AtenderAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusAgendamentoAtendendo();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Agendamento Alterado com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(CancelarAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusAgendamentoCancelado();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Agendamento Cancelado com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(CancelarPagamentoAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusPagamentoCancelado();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Pagamento Cancelado com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(CriarAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            Agendamento Agendamento = new Agendamento(command.ClienteId, command.Observacao);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            if (command.Procedimentos == null)
                return new GenericoAgendamentoCommandResult(false, "Não pode fazer um agendamento sem procedimentos!", command.Notifications);

            var Cliente = _clienteRepository.BuscarClienteId(command.ClienteId);

            if (Cliente == null)
                return new GenericoAgendamentoCommandResult(false, "Não pode fazer um agendamento sem cliente!", command.Notifications);

            Agendamento.AdicionarClienteId(Cliente.Id);

            foreach (var item in command.Procedimentos)
            {
                Agendamento.AdicionarProcedimento(item);
            }

            Agendamento.InserirObservacao(command.Observacao);


            _agendamentoRepository.Salvar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Pagamento Agendado com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(FinalizarAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusAgendamentoFinalizado();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Pagamento Finalizado com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(PagarPagamentoAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusPagamentoPago();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Pagamento Pago com Sucesso!", Agendamento);
        }

        public ICommandResult Handle(PendentePagamentoAgendamentoCommand command)
        {
            if (command.Valid() == false)
                return new GenericoAgendamentoCommandResult(false, "Ops Algo errado Aconteceu!", command.Notifications);

            var Agendamento = _agendamentoRepository.BuscarAgendamentoId(command.Id);

            if (Agendamento == null)
                return new GenericoAgendamentoCommandResult(false, "Não exite nenhum Agendamento com essa Id!", command.Notifications);

            Agendamento.ColocarStatusPagamentoPendente();
            Agendamento.AtualizarDataUltimaAtualizacao();
            Agendamento.InserirObservacao(command.Observacao);

            _agendamentoRepository.Editar(Agendamento);

            return new GenericoAgendamentoCommandResult(true, "Pagamento Colocado como Pendente com Sucesso!", Agendamento);
        }
    }
}