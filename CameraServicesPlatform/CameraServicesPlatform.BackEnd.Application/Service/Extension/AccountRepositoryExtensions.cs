using CameraServicesPlatform.BackEnd.Application.IRepository;
using CameraServicesPlatform.BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.Service.Extension
{
    public static class AccountRepositoryExtensions
    {
        public static async Task<Account> GetAccountByEmail(this IRepository<Account> repository, string email, bool? IsDeleted = false, bool? IsVerified = true)
        {
            return await repository.GetByExpression(u =>
                u!.Email.ToLower() == email.ToLower()
                && (IsDeleted == null || u.IsDeleted == IsDeleted)
                && (IsVerified == null || u.IsVerified == IsVerified));
        }
    }
}
