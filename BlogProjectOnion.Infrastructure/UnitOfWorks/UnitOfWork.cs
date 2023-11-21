using BlogProjectOnion.Domain.Repositories;
using BlogProjectOnion.Infrastructure.Context;
using BlogProjectOnion.Infrastructure.Repositories;

namespace BlogProjectOnion.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnıtOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


        IBaseRepository<T> IUnıtOfWork.GetRepository<T>()
        {
            return new BaseRepository<T>(_dbContext);
        }
    }
}
