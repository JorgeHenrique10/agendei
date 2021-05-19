using System;
using System.Collections.Generic;
using Agendei.Api.Services;
using Agendei.Dominio.Commands.AgendamentoCommand.Saidas;
using Agendei.Dominio.Commands.UsuarioCommand.Entradas;
using Agendei.Dominio.Commands.UsuarioCommand.Saidas;
using Agendei.Dominio.Entities;
using Agendei.Dominio.Handlers;
using Agendei.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agendei.Api.Controllers
{
    [ApiController]
    [Route("v1/Usuarios")]
    public class UsuarioController : ControllerBase
    {

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public GenericoUsuarioCommandResult GetLogin([FromServices] IUsuarioRepository repository, [FromBody] Usuario usuario)
        {
            if (usuario.Login == null || usuario.Senha == null)
                return new GenericoUsuarioCommandResult(false, "Login ou Senha está nullo!", usuario);

            var Objeto = repository.Login(usuario.Login, usuario.Senha);

            if (Objeto == null)
                return new GenericoUsuarioCommandResult(false, "Não foi encontrado nenhum usuário", usuario);

            var Token = TokenService.GenerateToken(Objeto);

            return new GenericoUsuarioCommandResult(true, "Usuario Logado com sucesso!", new { usuarioId = usuario.Id, usuario = usuario.Nome, token = Token });

        }

        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public IEnumerable<Usuario> BuscarTodosUsuarios([FromServices] IUsuarioRepository repository)
        {
            return repository.BuscarTodosUsuarios();
        }

        [Authorize]
        [Route("/{id}")]
        [HttpGet]
        public Usuario BuscarUsuarioId([FromServices] IUsuarioRepository repository, Guid id)
        {
            return repository.BuscarUsuarioId(id);
        }

        [Route("")]
        [HttpPost]
        public GenericoUsuarioCommandResult Criar([FromBody] CriarUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericoUsuarioCommandResult)handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public GenericoUsuarioCommandResult Editar([FromBody] EditarUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericoUsuarioCommandResult)handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpDelete]
        public GenericoUsuarioCommandResult Deletar([FromBody] DeletarUsuarioCommand command, [FromServices] UsuarioHandler handler)
        {
            return (GenericoUsuarioCommandResult)handler.Handle(command);
        }
    }
}