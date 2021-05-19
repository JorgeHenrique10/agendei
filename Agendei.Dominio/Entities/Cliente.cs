using System;
using System.ComponentModel.DataAnnotations;

namespace Agendei.Dominio.Entities
{
    public class Cliente : Entidade
    {
        public Cliente(string primeiroNome, string ultimoNome, string telefone, string email)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Telefone = telefone;
            Email = email;
        }
        [Required]
        [MinLength(2, ErrorMessage = "O Primeiro nome deve possuir no minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O Primeiro nome deve possuir no máximo 50 caracteres")]
        public string PrimeiroNome { get; private set; }

        [Required]
        [MinLength(2, ErrorMessage = "O Primeiro nome deve possuir no minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O Primeiro nome deve possuir no máximo 50 caracteres")]
        public string UltimoNome { get; private set; }

        [MinLength(10, ErrorMessage = "O Primeiro nome deve possuir no minimo 2 caracteres")]
        [MaxLength(11, ErrorMessage = "O Primeiro nome deve possuir no máximo 50 caracteres")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; private set; }

        public void AlterarNome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        public void AlterarEmail(string email)
        {
            Email = email;
        }
        public void AlterarTelefone(string telefone)
        {
            Telefone = telefone;
        }

    }
}