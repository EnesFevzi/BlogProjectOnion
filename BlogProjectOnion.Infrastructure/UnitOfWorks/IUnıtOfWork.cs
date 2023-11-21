using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Infrastructure.UnitOfWorks
{
    public interface IUnıtOfWork : IAsyncDisposable
    {
        IBaseRepository<T> GetRepository<T>() where T : class, IBaseEntity, new();

        Task<int> SaveAsync();
        int Save();
    }
}
