using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Agendei.Dominio.Enuns;

namespace Agendei.Dominio.Entities
{
    public class Agendamento : Entidade
    {
        private readonly List<Procedimento> _procedimentos;
        public Agendamento(Guid clienteId, string observacao)
        {
            ClienteId = clienteId;
            Observacao = observacao;
            DataAgendamento = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            StatusAgendamento = EAgendamentoStatus.Agendado;
            StatusPagamento = EPagamentoStatus.EmAberto;
            _procedimentos = new List<Procedimento>();
        }
        [Required]
        public DateTime DataAgendamento { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }

        [MaxLength(100, ErrorMessage = "O campo obseração deve conter no máximo 100 caracters")]
        public string Observacao { get; private set; }

        [Required]
        public EAgendamentoStatus StatusAgendamento { get; set; }

        [Required]
        public EPagamentoStatus StatusPagamento { get; set; }

        [Required]
        public Guid ClienteId { get; private set; }
        //public Cliente Cliente { get; set; }

        public IReadOnlyCollection<Procedimento> Procedimentos => _procedimentos.ToArray();

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            if (procedimento == null)
                throw new Exception("Procedimento O Procedimento não pode ser vazio!");

            _procedimentos.Add(procedimento);
        }

        public void InserirObservacao(string observacao)
        {
            Observacao = observacao;
        }
        public void AdicionarClienteId(Guid id)
        {
            ClienteId = id;
        }

        public void AtualizarDataUltimaAtualizacao()
        {
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void ColocarStatusPagamentoPago()
        {
            StatusPagamento = EPagamentoStatus.Pago;
        }
        public void ColocarStatusPagamentoPendente()
        {
            StatusPagamento = EPagamentoStatus.Pendente;
        }

        public void ColocarStatusPagamentoCancelado()
        {
            StatusPagamento = EPagamentoStatus.Cancelado;
        }
        public void ColocarStatusAgendamentoCancelado()
        {
            StatusAgendamento = EAgendamentoStatus.Cancelado;
        }
        public void ColocarStatusAgendamentoAtendendo()
        {
            StatusAgendamento = EAgendamentoStatus.Atendendo;
        }
        public void ColocarStatusAgendamentoFinalizado()
        {
            StatusAgendamento = EAgendamentoStatus.Finalizado;
        }

    }
}