using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest :IRequest<LoginCommandResponse>
    {
        [DefaultValue("")] //sistemde kayıtlı emaili gir
        public string Email { get; set; }
      
        [DefaultValue("")] //sistemde kayıtlı şifreyi gir
        public string Password { get; set; }    
    }
}
