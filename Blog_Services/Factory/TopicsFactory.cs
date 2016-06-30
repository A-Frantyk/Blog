using Blog_Entity.Model;
using Blog_Services.ModelDTO;
using Blog_Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.Factory
{
    public class TopicsFactory : IFactory<TopicDTO, Topic>
    {
        private readonly IUnitOfWork _unit;

        public TopicsFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public TopicDTO Create(Topic topicObj)
        {
            if(topicObj == null)
            {

            }

            var topicDTO = new TopicDTO()
            {
                Topic_Number = topicObj.Topic_Number,
                Description = topicObj.Description,
                Topic_Title = topicObj.Topic_Title,
                Blog_Number = topicObj.Blog_Number
            };

            return topicDTO;
        }

        public Topic Parse(TopicDTO topicDtoObj)
        {
            throw new NotImplementedException();
        }
    }
}
