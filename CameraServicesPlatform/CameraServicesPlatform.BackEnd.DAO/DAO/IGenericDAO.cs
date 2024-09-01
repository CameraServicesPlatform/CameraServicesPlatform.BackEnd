using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
namespace CameraServicesPlatform.BackEnd.DAO.DAO
{
    public interface IGenericDAO<T> where T : class
    {
        Task<PagedResult<T>> GetAllDataByExpression(Expression<Func<T, bool>>? filter,
   int pageNumber, int pageSize,
   Expression<Func<T, object>>? orderBy = null,
   bool isAscending = true,
   params Expression<Func<T, object>>[]? includes);

        Task<T> GetById(object id);

        Task<T?> GetByExpression(Expression<Func<T?, bool>> filter,
            params Expression<Func<T, object>>[]? includeProperties);

        Task<T> Insert(T entity);

        Task<List<T>> InsertRange(IEnumerable<T> entities);

        Task<List<T>> DeleteRange(IEnumerable<T> entities);

        Task<T> Update(T entity);

        Task<T?> DeleteById(object id);
    }
}