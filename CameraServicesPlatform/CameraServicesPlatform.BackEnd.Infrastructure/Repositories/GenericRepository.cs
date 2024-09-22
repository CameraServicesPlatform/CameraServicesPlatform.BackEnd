using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using CameraServicesPlatform.BackEnd.DAO.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CameraServicesPlatform.BackEnd.Infrastructure.Repositories;
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly IDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(IDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<PagedResult<T>> GetAllDataByExpression(Expression<Func<T, bool>>? filter,
       int pageNumber, int pageSize,
       Expression<Func<T, object>>? orderBy = null,
       bool isAscending = true,
       params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (orderBy != null)
        {
            query = isAscending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
        }

        var totalItems = await query.CountAsync();
        var result = new PagedResult<T>
        {
            Items = null,
            TotalPages = 0
        };
        if (pageNumber > 0 && pageSize > 0)
        {
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            result.Items = await query.AsNoTracking().ToListAsync();
            result.TotalPages = totalPages;
            return result;
        }

        var data = await query.AsNoTracking().ToListAsync();
        result.Items = data;
        result.TotalPages = data.Count() > 0 ? 1 : 0;
        return result;
    }

    public async Task<T> GetById(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> Insert(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<T> DeleteById(object id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        if (entityToDelete != null) _dbSet.Remove(entityToDelete);
        return entityToDelete;
    }

    public async Task<T> GetByExpression(Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbSet;

        if (includeProperties != null)
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

        return await query.SingleOrDefaultAsync(filter);
    }

    public async Task<List<T>> InsertRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
        return entities.ToList();
    }

    public async Task<List<T>> DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        return entities.ToList();
    }
}