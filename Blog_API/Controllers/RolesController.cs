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
    [RoutePrefix("api/roles")]
    public class RolesController : BaseController.BaseController<RolesDTO, Roles>
    {
        public RolesController(IUnitOfWork unit, [Named("RolesFCTR")] IFactory<RolesDTO, Roles> factory)
            :base(unit, factory)
        {
        }

        public async Task<IEnumerable<RolesDTO>> GetAll()
        {
            var items = await UnitOfWork.RolesItemRepository.Get();

            var result = items.ToList().Select(a => Factory.Create(a));

            return result;
        }


    }
}
