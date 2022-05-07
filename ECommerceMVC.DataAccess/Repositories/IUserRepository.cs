using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IList<User>> SearchUsersByName(string name);

    }
}
