using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Domain.Common;
using HepsiBuradaApi.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;
        public ReadRepository(AppDbContext dbcontext) {
            context = dbcontext;
        }
        private DbSet<T> Table { get=> context.Set<T>(); }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            Table.AsNoTracking();
            if(predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enabletracking=false)
        {
            if (!enabletracking) Table.AsNoTracking();
            return  Table.Where(predicate);
        }

        public async Task<IList<T>> getAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderby is not null) 
                return await orderby(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> getAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderby is not null)
                return await orderby(queryable).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<T> getAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
           // queryable = queryable.Where(predicate);


            return await queryable.FirstOrDefaultAsync(predicate);
        }
    }
}
