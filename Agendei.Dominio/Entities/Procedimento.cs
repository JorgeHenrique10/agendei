using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agendei.Dominio.Entities
{
    public class Procedimento : Entidade
    {
        private readonly List<Agendamento> _agendamentos;
        public Procedimento(string nome, string descricao, double valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            _agendamentos = new List<Agendamento>();
        }

        [Required]
        [MinLength(2, ErrorMessage = "O nome deve possuir no minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "A descricao nome deve possuir no máximo 100 caracteres")]
        public string Descricao { get; private set; }

        [Required]
        public double Valor { get; private set; }

        public IReadOnlyCollection<Agendamento> Agendamentos => _agendamentos.ToArray();

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void AlterarValor(double valor)
        {
            Valor = valor;
        }
    }
}