﻿using HepsiApi.Application.Interfaces.Repositories;
using HepsiApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork :IAsyncDisposable //UnitOfWork işlemleri takip edip düzgün bir şekilde işlemleri yapmamızı sağlıyor ör guncelleme yoksa disposable yapıyor
    {
        IReadRepository<T> GetReadRepository<T>() where T : class,IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class,IEntityBase,new();
        Task<int> SaveAsync();
        int Save();

    }
}
