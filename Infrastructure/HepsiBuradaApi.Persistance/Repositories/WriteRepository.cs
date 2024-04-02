using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Domain.Common;
using HepsiBuradaApi.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class,IEntityBase,new()
    {
        private readonly AppDbContext context;
        public WriteRepository(AppDbContext dbcontext)
        {
            context = dbcontext;
        }
        private DbSet<T> Table { get => context.Set<T>(); }

        public async Task addAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public async Task addRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public Task hardDeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> updateAsync(T entity)
        {
           await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
}
