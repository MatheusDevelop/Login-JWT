using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtApi.Contexts;
using JwtApi.Domains;
using JwtApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        UsuarioContexts con = new UsuarioContexts();
        private IConfiguration _config;
        Hash hash = new Hash();

        // Definimos um método construtor para poder passar essas configs
        public SignController(IConfiguration config)
        {
            _config = config;
        }


        private Usuarios UserAuth(Usuarios u)
        {
            return con.Usuarios.FirstOrDefault(e => e.Nome == u.Nome && e.Senha == u.Senha);
        }


        private string GenerateJSONWebToken(Usuarios userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

           
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Senha),
            new Claim(JwtRegisteredClaimNames.Sid, userInfo.IdUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           
            };

            var token = new JwtSecurityToken
                (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        


        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usuarios login)
        {
            var userVerify = new Usuarios();
            userVerify.Nome = login.Nome;
            userVerify.Senha = hash.GenerateHash(login.Senha,login.Nome);

            var user = UserAuth(userVerify);
            if (user != null)
            {
                return Ok(new { token = GenerateJSONWebToken(user)});
            }

            return Unauthorized();
        }




    }
}
