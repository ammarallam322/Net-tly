
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using teamProject.Models;

namespace teamProject.Repository
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
      
        //
        public TeamContext context;

        public RepositoryGeneric(TeamContext context)
        {
            this.context = context;
          
        }


        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public void Add(TEntity obj)
        {
             context.Set<TEntity>().Add(obj);
        }

        public void Delete(int id)
        {
            context.Set<TEntity>().Remove(GetById(id));
        }

        public void Update(TEntity obj)
        {
            context.Set<TEntity>().Update(obj);
        }
        public void Save()
        {
            context.SaveChanges();
        }

      
    }
}
