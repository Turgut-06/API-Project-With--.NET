using HepsiApi.Application.Interfaces.Repositories;
using HepsiApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Persistence.Repositories
{
    public class WriteRepository<T> :IWriteRepository<T> where T : class,IEntityBase,new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } //her seferinde dbContext i set etmek yerine bir tane bu görevi yapan Table fonksiyonu yazıyoruz DbSet tipinde 

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity)); //kendi asenkron metodumu yazıyorum update işlemi için hazır async metot yok
            return entity;
        }
        public async Task HardDeleteAsync(T entity)
        {

            await Task.Run(() => Table.Remove(entity)); //kendi asenkron metodumu yazıyorum delete işlemi için hazır async metot yok

        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {

            await Task.Run(() => Table.RemoveRange(entity)); //kendi asenkron metodumu yazıyorum delete işlemi için hazır async metot yok

        }




    }
}
