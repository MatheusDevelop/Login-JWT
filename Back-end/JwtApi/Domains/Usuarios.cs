using System;
using System.Collections.Generic;

namespace JwtApi.Domains
{
    public partial class Usuarios
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        public Usuarios()
        {
            IdUsuario = Guid.NewGuid();
        }
    }
}
