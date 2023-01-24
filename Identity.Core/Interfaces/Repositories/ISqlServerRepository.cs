using System.Linq.Expressions;

namespace Identity.Core.Interfaces.Repositories
{
    public interface ISqlServerRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>>? filter = null!,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null!,
            string includeProperties = "");

        IEnumerable<TEntity> All();
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(object id);
        void Remove(TEntity entityToRemove);
        void Remove(object id);
        void Update(TEntity entityToUpdate);
        void Add(TEntity entity);
        IQueryable<TEntity> Query { get; }

        //IQueryable<TEntity> GetJson();
    }
}
