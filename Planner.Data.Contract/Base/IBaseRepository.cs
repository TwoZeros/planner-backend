using Planner.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Contract.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        List<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetByIds(IEnumerable<int> ids);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task Delete(int id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        IQueryable<TEntity> Query();

        Task SaveAsync();
        
    }
}
