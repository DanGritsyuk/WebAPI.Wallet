﻿using Wallet.Common.Entities.User.DB;

namespace Wallet.DAL.Repository.Contracts
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(Guid id);
    }
}