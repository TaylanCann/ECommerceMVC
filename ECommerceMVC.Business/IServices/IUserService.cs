using ECommerceMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.Business.IServices
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
    }
}
