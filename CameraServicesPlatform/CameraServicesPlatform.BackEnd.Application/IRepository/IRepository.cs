using CameraServicesPlatform.BackEnd.Common.DTO.Response;
 
using CameraServicesPlatform.BackEnd.Domain.Models;
 
using System.Linq.Expressions;

namespace CameraServicesPlatform.BackEnd.Application.IRepository;

public interface IRepository<T> where T : class
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
    Task<T?> GetSingleByExpressionAsync(Expression<Func<T, bool>> expression);

}
