using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private ECommerceDbContext context;
        public EFUserRepository(ECommerceDbContext context)
        {
            this.context = context;
        }
        public Task<int> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<User>> GetAllEntities()
        {
            return await context.Users.Where(p => p.IsActive == true).ToListAsync();

        }

        public Task<User> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> SearchUsersByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
