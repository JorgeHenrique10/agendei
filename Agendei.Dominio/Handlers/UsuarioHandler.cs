using Agendei.Dominio.Commands.UsuarioCommand.Entradas;
using Agendei.Dominio.Commands.ContractCommands;
using Agendei.Dominio.Commands.UsuarioCommand.Saidas;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Repositories;

namespace Agendei.Dominio.Handlers
{
    public class UsuarioHandler : ICommandHandler<CriarUsuarioCommand>, ICommandHandler<EditarUsuarioCommand>, ICommandHandler<DeletarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuariorepository;
        public UsuarioHandler(IUsuarioRepository repository)
        {
            _usuariorepository = repository;
        }

        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            //Fail Fast Validator
            if (!command.Valid())
                return new GenericoUsuarioCommandResult(false, "Ops parece que o Usuario que quer adicionar possui algum erro!", command.Notifications);

            //Criar um Usuario
            Usuario Usuario = new Usuario(command.Nome, command.Login, command.Senha, command.Perfil);

            //Salvar um Clinte
            _usuariorepository.Salvar(Usuario);

            //Retornar o Usuario
            return new GenericoUsuarioCommandResult(true, "Usuário adicionando com sucesso!", Usuario);
        }

        public ICommandResult Handle(EditarUsuarioCommand command)
        {
            if (!command.Valid())
                return new GenericoUsuarioCommandResult(false, "Ops parece que o Usuario que quer editar possui algum erro!", command.Notifications);

            var Usuario = _usuariorepository.BuscarUsuarioId(command.Id);
            if (Usuario == null)
                return new GenericoUsuarioCommandResult(false, "Usuario não encontrado", command.Notifications);

            Usuario.AlterarNome(command.Nome);
            Usuario.AlterarLogin(command.Login);
            Usuario.AlterarPerfil(command.Perfil);
            Usuario.AlterarSenha(command.Senha);

            _usuariorepository.Editar(command);

            return new GenericoUsuarioCommandResult(true, "Usuario Editado com sucesso!", Usuario);
        }

        public ICommandResult Handle(DeletarUsuarioCommand command)
        {
            if (!command.Valid())
                return new GenericoUsuarioCommandResult(false, "Ops parece que o Usuario que quer deletar possui algum erro!", command.Notifications);

            if (_usuariorepository.BuscarUsuarioId(command.Id) == null)
                return new GenericoUsuarioCommandResult(false, "Usuario não encontrado", command.Notifications);

            _usuariorepository.Deletar(command.Id);

            return new GenericoUsuarioCommandResult(true, "Usuario Deletado com sucesso!", command.Nome);
        }
    }
}