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
    public class UsuarioController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ResponsePadrao Post([FromBody] UsuarioLoginRequest value)
        {
            return UsuarioRepository.Login(value.Login, value.Senha);
        }
    }
}