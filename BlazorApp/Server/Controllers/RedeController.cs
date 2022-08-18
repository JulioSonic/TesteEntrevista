using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedeController : ControllerBase
    {
        private readonly IRede _Irede;

        public RedeController(IRede iRede)
        {
            _Irede = iRede;
        }

        [HttpGet]
        public async Task<List<Rede>> Get()
        {
            return await Task.FromResult(_Irede.ListaRedes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Rede rede = _Irede.RetornaRedePorId(id);
            if (rede != null)
            {
                return Ok(rede);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Rede rede)
        {
            _Irede.AdicionaRede(rede);
        }

        [HttpPut]
        public void Put(Rede rede)
        {
            _Irede.AtualizaRede(rede);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _Irede.DeletaRede(id);
            return Ok();
        }
    }
}
