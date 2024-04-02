using HepsiBuradaApi.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class,IEntityBase,new()
    {
        Task<IList<T>> getAllAsync(Expression<Func<T,bool>>? predicate= null,Func<IQueryable<T>,IIncludableQueryable<T,object>>? include = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderby = null,
            bool enableTracking = false);
        Task<IList<T>> getAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            bool enableTracking = false,int currentPage = 1,int pageSize=3);
        Task<T> getAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enabletracking=false);
        Task<int> CountAsync(Expression<Func<T,bool>> predicate=null);
    }
}
