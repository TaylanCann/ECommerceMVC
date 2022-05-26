using AutoMapper;
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
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<User> ValidateUser(string UserName, string Password)
        {

            return await userRepository.Validate(UserName, Password);
        }
    }
}
