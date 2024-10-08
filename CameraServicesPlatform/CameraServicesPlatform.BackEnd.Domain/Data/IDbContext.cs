using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CameraServicesPlatform.BackEnd.Data
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

        EntityEntry<T> Entry<T>(T entity) where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}