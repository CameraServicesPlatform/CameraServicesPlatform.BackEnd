namespace CameraServicesPlatform.BackEnd.Application;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}

