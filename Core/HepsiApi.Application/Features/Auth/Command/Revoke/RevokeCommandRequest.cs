using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandRequest :IRequest<Unit> //response unu Unit olarak veriyorum
    {
        public string Email { get; set; }
    }
}
