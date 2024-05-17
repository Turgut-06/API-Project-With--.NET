using HepsiApi.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class,IEntityBase,new()
    {
        //1. expression isDeleted ları true olanları da getirmeni sağlar dateTime ları belli aralıklarda olanları almanı sağlar bu expression null olduğundan boş geçilebiliyor
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, //çoka çok tablolar için productan category e de erişmek için thenInclude yazmanı sağlar
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,   //bu kısım ör. price(fiyat)  a göre sıralama yapılmasını sağlar ucuzdan pahalıya gibi
            bool enableTracking = false);

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, //çoka çok tablolar için productan category e de erişmek için thenInclude yazmanı sağlar
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,   //bu kısım ör. price(fiyat)  a göre sıralama yapılmasını sağlar ucuzdan pahalıya gibi
            bool enableTracking = false, int currentPage=1,int pageSize=3);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate ,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, //çoka çok tablolar için productan category e de erişmek için thenInclude yazmanı sağlar
           bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false); //list tipinde dönmeyen sorgumuz

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
