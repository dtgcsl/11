using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Entities;

namespace Web.Repository.Common
{
    public class BaseRepository<T> where T : class
    {
        protected readonly SchoolContext _dbContext;

        public BaseRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public async Task<T> GetById(Guid id)
        {
            var obj = await _dbContext.Set<T>().FindAsync(id);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            return obj;
        }

        public async Task Add(T t)
        {
            await _dbContext.Set<T>().AddAsync(t);
        }
        public Task Update(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task Delete(Guid id) {
            var obj = await _dbContext.Set<T>().FindAsync(id);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            _dbContext.Set<T>().Remove(obj);
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
