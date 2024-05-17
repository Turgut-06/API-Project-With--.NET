using HepsiApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpired :BaseException
    {
        public RefreshTokenShouldNotBeExpired() :base("Oturum süreniz dolmuştur Tekrar giriş yapınız") { }
      
    }
}
