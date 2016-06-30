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
    public class TopicsController : BaseController.BaseController<TopicDTO, Topic>
    {
        public TopicsController(IUnitOfWork unit, [Named("TopicFCTR")] IFactory<TopicDTO, Topic> topicFactory) : base(unit, topicFactory)
        {
        }

        [HttpGet]
        public IEnumerable<TopicDTO> GetTopic()
        {
            IQueryable<Topic> query;

            query = UnitOfWork.TopicItemRepository.Get();

            var result = query.ToList().Select(a => Factory.Create(a));

            return result.ToList();
        }
    }
}
