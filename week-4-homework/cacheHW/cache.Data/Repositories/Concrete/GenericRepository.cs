using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace cacheHW.Data
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext Context;
        private DbSet<Entity> entities;

        public GenericRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<Entity>();
        }
    }
}
