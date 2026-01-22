using Esnafim_1.Application.Interfaces.UserInterfaces;
using Esnafim_1.Domain.Entities;
using Esnafim_1.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EsnafimContext _context;

        public  UserRepository(EsnafimContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var normalized = email.Trim().ToLower();

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.ToLower() == normalized);
        }
    }
}
