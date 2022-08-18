using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _IUser;

        public UsuarioController(IUsuario iUser)
        {
            _IUser = iUser;
        }

        [HttpGet]
        public async Task<List<Usuario>> Get()
        {
            return await Task.FromResult(_IUser.ListaUsuarios());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Usuario user = _IUser.RetornaUsuarioPorId(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Usuario user)
        {
            _IUser.AdicionaUsuario(user);
        }

        [HttpPut]
        public void Put(Usuario user)
        {
            _IUser.AtualizaUsuario(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IUser.DeletaUsuario(id);
            return Ok();
        }
    }
}
