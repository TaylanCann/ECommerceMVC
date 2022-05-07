using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        public Task<int> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllEntities()
        {
            throw new NotImplementedException();
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
