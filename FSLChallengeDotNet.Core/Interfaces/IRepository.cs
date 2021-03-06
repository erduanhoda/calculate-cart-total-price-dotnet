using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FSLChallengeDotNet.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<List<T>> ListAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
