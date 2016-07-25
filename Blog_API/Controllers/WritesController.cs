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
using Ninject;
using System.Threading.Tasks;

namespace Blog_API.Controllers
{
    [RoutePrefix("api/write")]
    public class WritesController : BaseController.BaseController<WritesDTO, Writes>
    {
        public WritesController( IUnitOfWork unit, [Named("WritesFCTR")] IFactory<WritesDTO, Writes> factoryObj) : base(unit, factoryObj)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<WritesDTO>> GetWrites()
        {
            var writes = await UnitOfWork.WritesItemRepository.Get();

            var result = writes.ToList().Select(a => Factory.Create(a));

            return result;   
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetWritesByID(int id)
        {
            var write = UnitOfWork.WritesItemRepository.GetByID(id);

            if(write != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(write));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "An appropriate write not found!");
            }
        }

        [HttpGet]
        [Route("getbytopicId/{topicID}")]
        public async Task<IEnumerable<WritesDTO>> GetWritesByTopicID(int topicID)
        {
            var writes = await UnitOfWork.WritesItemRepository.Get(i => i.Topic_Number == topicID);

            var result = writes.ToList().Select(a => Factory.Create(a));

            return result;
        }

        [HttpGet]
        [Route("all/{topicId}")]
        public async Task<IEnumerable<string>> GetWritesTitle(int topicId)
        {
            var items = await UnitOfWork.WritesItemRepository.Get(i => i.Topic_Number == topicId);

            var titles = items.Select(a => a.Title);

            return titles;
        }

        [HttpPut]
        [Route("edit")]
        public async Task<HttpResponseMessage> EditWrite([FromBody] WritesDTO write)
        {
            var writes = await Factory.Parse(write);

            if(writes != null)
            {
                UnitOfWork.WritesItemRepository.Update(writes);

                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(writes));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Edit write is not acceptable!!");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> AddWrite([FromBody] WritesDTO write)
        {
            var writeToAdd = await Factory.Parse(write);

            if(writeToAdd != null)
            {
                UnitOfWork.WritesItemRepository.Insert(writeToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(writeToAdd));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Cannot add new writes!!!");
            }
        }
    }
}
