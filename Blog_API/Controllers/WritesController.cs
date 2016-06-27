using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Blog_API.Controllers.BaseController;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using Blog_Entity.Model;
using Blog_Services.Factory;

namespace Blog_API.Controllers
{
    public class WritesController : BaseController.BaseController
    {
        public WritesController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IEnumerable<WritesDTO> GetWrites()
        {
            IQueryable<Writes> query;

            query = UnitOfWork.WritesItemRepository.Get();

            var result = query.ToList().Select(a => WritesFactory.Create(a));

            return result;   
        }
    }
}
