using Identity.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Identity.Infrastructure.Data.Repositories
{
    public class SqlServerRepository<TEntity> : ISqlServerRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly AppDataContext _context;

        public SqlServerRepository(AppDataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Utilizar esta propriedade quando for necessário montar uam instrução SQL diretamente no banco.
        /// Todas as operações feitas nessa propriedade serão executadas diretamente no banco de dados e não na memória.
        /// </summary>
        public virtual IQueryable<TEntity> Query
        {
            get { return _dbSet.AsQueryable(); }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public TEntity? GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public void Remove(TEntity entityToRemove)
        {
            if (_context.Entry(entityToRemove).State == EntityState.Detached)
                _dbSet.Attach(entityToRemove);

            _dbSet.Remove(entityToRemove);
        }

        public void Remove(object id)
        {
            TEntity entityToRemove = _dbSet.Find(id)!;
            Remove(entityToRemove);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        //public IQueryable<TEntity> GetJson()
        //{
        //    var userId = new SqlParameter("@UserId", 1);
        //    var entityJson = _dbSet.FromSqlRaw("EXEC GetUserCompanyAccessTeste @UserId", userId);

        //    return entityJson;
        //}
    }
}
