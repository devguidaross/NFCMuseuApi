using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseuApi.Db;
using MuseuApi.Entities;
using MuseuApi.Models;
using MuseuApi.Models.Requests;
using MuseuApi.Repository;

namespace MuseuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ResponsePadrao Get(bool aAtivo)
        {
            var lItem = Startup.MuseuContext.Item.Where(w => w.Ativo == aAtivo).ToList();
            return new ResponsePadrao()
            {
                Sucesso = true,
                Data = lItem,
                Mensagem = "Itens retornados com sucesso!"
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ResponsePadrao Get(int aId)
        {
            var lItem = Startup.MuseuContext.Item.FirstOrDefault(w => w.Id == aId);
            return new ResponsePadrao()
            {
                Sucesso = lItem != null,
                Data = lItem,
                Mensagem = (lItem == null ? "Não houve " : "") + "Itens encontrados!"
            };
        }

        // POST api/values
        [HttpPost]
        public ResponsePadrao Post([FromBody] ItemRequest value)
        {
            var lLogin = UsuarioRepository.Login(value.Login, value.Senha);
            
            return lLogin.Sucesso ? ItemRepository.NovoItem(value.Item) : lLogin;
        }
    }
}