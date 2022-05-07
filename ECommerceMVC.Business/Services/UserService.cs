using ECommerceMVC.Business.IServices;
using ECommerceMVC.DataAccess.Repositories;
using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> ValidateUser(string UserName, string Password)
        {

            return userRepository.Validate(UserName, Password);
        }
    }
}
