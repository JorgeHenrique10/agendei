using Agendei.Dominio.Commands.ContractCommands;
using FluentValidator;
using FluentValidator.Validation;

namespace Agendei.Dominio.Commands.UsuarioCommand.Entradas
{
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        public CriarUsuarioCommand()
        {

        }
        public CriarUsuarioCommand(string nome, string login, string senha, string perfil)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Perfil = perfil;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O campo deve conter no mínimo 3 caracteres")
                .HasMinLen(Login, 3, "Login", "O campo deve conter no mínimo 3 caracteres")
                .HasMinLen(Senha, 3, "Senha", "O campo deve conter no mínimo 3 caracteres")
                .HasMinLen(Perfil, 1, "Perfil", "O campo deve conter no mínimo 1 caracteres")
                .HasMaxLen(Nome, 200, "Nome", "O campo deve conter no maximo 200 caracteres")
                .HasMaxLen(Login, 10, "Login", "O campo deve conter no maximo 10 caracteres")
                .HasMaxLen(Senha, 12, "Senha", "O campo deve conter no maximo 12 caracteres")
                .HasMaxLen(Perfil, 10, "Perfil", "O campo deve conter no maximo 10 caracteres")
            );

            return IsValid;
        }
    }
}