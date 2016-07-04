using Blog_Entity.Model;
using Blog_Services.Factory;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog_API.Controllers
{
    public class UserController : BaseController.BaseController<UserDTO,User>
    {
        public UserController( IUnitOfWork unit, [Named("UserFCTR")] IFactory<UserDTO ,User> factoryObj ) : base(unit, factoryObj)
        {

        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            IQueryable<User> query;

            query = UnitOfWork.UserItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
    }
}
