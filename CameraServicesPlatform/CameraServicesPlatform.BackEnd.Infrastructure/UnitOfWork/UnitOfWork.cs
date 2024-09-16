

using CameraServicesPlatform.BackEnd.Application;
using CameraServicesPlatform.BackEnd.DAO.Data;

namespace CameraServicesPlatform.BackEnd.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbContext _context;

    public UnitOfWork(IDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}