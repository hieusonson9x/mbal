using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using Microsoft.EntityFrameworkCore;

namespace mbal.Repository
{
    public class BaseRepository<TEntity> where TEntity: class
    {
        internal UserContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(UserContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
    }
}
