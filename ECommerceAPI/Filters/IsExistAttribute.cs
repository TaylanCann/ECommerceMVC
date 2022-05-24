using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerceAPI.Filters
{
    public class IsExistAttribute : TypeFilterAttribute
    {
        public IsExistAttribute() : base(typeof(CheckExisting))
        {

        }
    }
}
