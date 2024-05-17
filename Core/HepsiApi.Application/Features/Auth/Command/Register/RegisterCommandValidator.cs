using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator :AbstractValidator<RegisterCommandRequest>
    {

        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("isim soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress() //otomatik emailAdress validation işlemi oluyor
                .MaximumLength(60)
                .MinimumLength(8)
                .WithName("E-posta adresi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("parola");

            /*
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Parola Tekrarı");
            
            */
        }
    }
}
