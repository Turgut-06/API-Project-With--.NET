using HepsiApi.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Behaviours
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if(request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedData != null)
                    return cachedData; //Cachelenmiş data varsa onu dönder

                var response = await next(); //response a geçiş yaptık
                if(response != null)
                    await redisCacheService.SetAsync(cacheKey, response,DateTime.Now.AddMinutes(cacheTime));

                return response; //behaviourı tamamladım
            }
            return await next(); //middleware arasına girecek kontrol sağlayacak işlem tamamsa yukarda da response a geçebilir
        }
    }
}
