using System;
using System.ComponentModel.DataAnnotations;

namespace Agendei.Dominio.Entities
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string login, string senha, string perfil)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Perfil = perfil;
        }

        [Required]
        [MinLength(2, ErrorMessage = "O nome deve possuir no minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome deve possuir no máximo 50 caracteres")]
        public string Nome { get; private set; }

        [Required]
        [MinLength(2, ErrorMessage = "O login deve possuir no minimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O login deve possuir no máximo 50 caracteres")]
        public string Login { get; private set; }

        [Required]
        [MinLength(4, ErrorMessage = "A senha nome deve possuir no minimo 4 caracteres")]
        [MaxLength(8, ErrorMessage = "A senha nome deve possuir no máximo 8 caracteres")]
        public string Senha { get; private set; }

        [Required]
        public string Perfil { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarLogin(string login)
        {
            Login = login;
        }
        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }
        public void AlterarPerfil(string perfil)
        {
            Perfil = perfil;
        }
    }
}
