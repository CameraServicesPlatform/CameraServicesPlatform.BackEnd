﻿namespace CameraServicesPlatform.BackEnd.Application;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    public Task SaveChangeAsync();
}

