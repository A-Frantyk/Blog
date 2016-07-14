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
    [RoutePrefix("api/user")]
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

        [HttpGet]
        [Route("{userID}")]
        public HttpResponseMessage GetUserByID(int userID)
        {
            var user = UnitOfWork.UserItemRepository.GetByID(userID);

            if(user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(user));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found!!!");
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddUser( [FromBody] UserDTO userDTO)
        {
            var user = Factory.Parse(userDTO);

            if (user != null)
            {
                UnitOfWork.UserItemRepository.Insert(user);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(user));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot add new user!!!");
            }
        }
    }
}
