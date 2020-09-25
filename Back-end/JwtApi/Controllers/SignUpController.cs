using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.Contexts;
using JwtApi.Domains;
using JwtApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SignUpController : ControllerBase
    {
        UsuarioContexts con = new UsuarioContexts();
        Hash hash = new Hash();
        private Usuarios UserCheck(Usuarios u)
        {
            return con.Usuarios.FirstOrDefault(e => e.Nome == u.Nome);
        }






        [HttpPost]
        public IActionResult Signup([FromBody] Usuarios userSingUp)
        {
            var checkUser = UserCheck(userSingUp);

            if(checkUser == null)
            {
                var cripUser = new Usuarios();                
                cripUser.Nome  = userSingUp.Nome;
                cripUser.Senha = hash.GenerateHash(userSingUp.Senha, userSingUp.Nome);

                con.Usuarios.Add(cripUser);
                con.SaveChanges();

                return Ok();
            }

            return Unauthorized();
        }



    }
}
