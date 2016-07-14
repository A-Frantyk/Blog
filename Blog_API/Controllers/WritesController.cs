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

namespace Blog_API.Controllers
{
    [RoutePrefix("api/write")]
    public class WritesController : BaseController.BaseController<WritesDTO, Writes>
    {
        public WritesController( IUnitOfWork unit, [Named("WritesFCTR")] IFactory<WritesDTO, Writes> factoryObj) : base(unit, factoryObj)
        {
        }

        [HttpGet]
        public IEnumerable<WritesDTO> GetWrites()
        {
            var writes = UnitOfWork.WritesItemRepository.Get();

            var result = writes.ToList().Select(a => Factory.Create(a));

            return result;   
        }

        [HttpGet]
        [Route("api/writes/{id}")]
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
        [Route("api/topic/writes/{topicID}")]
        public IEnumerable<WritesDTO> GetWritesByTopicID(int topicID)
        {
            var writes = UnitOfWork.WritesItemRepository.Get(i => i.Topic_Number == topicID);

            var result = writes.ToList().Select(a => Factory.Create(a));

            return result;
        }

        [HttpPut]
        public HttpResponseMessage EditWrite([FromBody] WritesDTO write)
        {
            var writes = Factory.Parse(write);

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
        public HttpResponseMessage AddWrite([FromBody] WritesDTO write)
        {
            var writeToAdd = Factory.Parse(write);

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
