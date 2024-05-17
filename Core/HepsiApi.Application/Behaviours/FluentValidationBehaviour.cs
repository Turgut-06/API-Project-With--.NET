using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Behaviours
{
    public class FluentValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> //request e response dönecek diyoruz
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request); //request le gelen contexti validationContext ile yakaladım
            var failtures = validator //hatalar
                .Select(v => v.Validate(context)) //request içindeki property ler için
                .SelectMany(result => result.Errors) //birden fazla hata olabilir
                .GroupBy(x => x.ErrorMessage) //aynı mesajdan birden fazla varsa benim için gruplar
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();

            if(failtures.Any()) //failtures da herhangi bir data varsa
            {
                throw new ValidationException(failtures);

            }

            return next(); //responsa a yönlendirmiş oluyoruz
        }
    }
}
