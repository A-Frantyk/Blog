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

        [HttpGet]
        [Route("api/topics/{topicID}")]
        public HttpResponseMessage GetTopicByID(int topicID)
        {
            Topic topic = UnitOfWork.TopicItemRepository.GetByID(topicID);

            if(topic != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(topic));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Topic not found!");
            }
        }

        [HttpGet]
        [Route("api/blog/topics/{blogID}")]
        public HttpResponseMessage GetTopicByBlogID(int blogID)
        {
            Topic topic = UnitOfWork.TopicItemRepository.Get(i => i.Blog_Number == blogID)
                                                        .FirstOrDefault();

            if(topic != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(topic));
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Topic not found!");
            }
        }

        [HttpPost]
        public HttpResponseMessage AddTopic([FromBody] TopicDTO topic)
        {
            Topic topicToAdd = Factory.Parse(topic);

            if(topicToAdd != null)
            {
                UnitOfWork.TopicItemRepository.Insert(topicToAdd);

                return Request.CreateResponse(HttpStatusCode.Created, Factory.Create(topicToAdd));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Topic not added");
            }
        }

        [HttpPut]
        public HttpResponseMessage EditTopic([FromBody] TopicDTO topic)
        {
            Topic topicToEdit = Factory.Parse(topic);

            if(topicToEdit != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Factory.Create(topicToEdit));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Topic not modifyied!!");
            }
        }
    }
}
