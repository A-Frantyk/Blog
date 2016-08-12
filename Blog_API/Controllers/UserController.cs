using Blog_API.Controllers.BaseController;
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
using System.Threading.Tasks;
using System.Web.Http;

namespace Blog_API.Controllers
{
    [RoutePrefix("api/user")]
    [AllowAnonymous]
    public class UserController : BaseController<UserDTO, User>
    {
        public UserController(IUnitOfWork unit, [Named("UserFCTR")] IFactory<UserDTO, User> factoryObj) : base(unit, factoryObj)
        {

        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IQueryable<User> query;

            query = await UnitOfWork.UserItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }

        [HttpGet]
        [Route("{userID}")]
        public async Task<HttpResponseMessage> GetUserByID(int userID)
        {
            var user = await UnitOfWork.UserItemRepository.GetByID(userID);

            if (user != null)
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
        public async Task<HttpResponseMessage> AddUser([FromBody] UserDTO user)
        {
            if (user != null)
            {
                var userToAdd = await Factory.Parse(user);

                UnitOfWork.UserItemRepository.Insert(userToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(userToAdd));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot add new user!!!");
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<HttpResponseMessage> EditUser([FromBody] UserDTO user)
        {
            if (user != null)
            {
                var userToEdit = await Factory.Parse(user);

                UnitOfWork.UserItemRepository.Update(userToEdit);

                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(userToEdit));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot edit user");
            }
        }
    }
}
