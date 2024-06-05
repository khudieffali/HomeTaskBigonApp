using Bigon.Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Commons.Concretes
{
    public abstract class Repository<T>: IRepository<T> where T : class
    {
        private readonly DbContext _db;

        protected Repository(DbContext db)
        {
            _db = db;
            _table=_db.Set<T>();
        }

        private readonly DbSet<T> _table;
       
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _table.ToListAsync();
            }
            var list =await  _table.Where(predicate).ToListAsync();
            return list;
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _table.FirstOrDefaultAsync();
            }
            var dbData = await _table.FirstOrDefaultAsync(predicate);
            return dbData;
        }
        public async Task<T> Add(T data)
        {
            await _table.AddAsync(data);
            await Save();
            return data;
        }
        public async Task<T> Edit(T data)
        {
            _table.Entry(data).State= EntityState.Modified;
            await Save();
            return data;
        }
        public async Task Remove(T data)
        {
              _table.Remove(data);
            await Save();
        }

        public async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }

    }
}
