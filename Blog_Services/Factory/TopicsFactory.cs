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
            if (topicDtoObj == null)
            {

            }

            if (topicDtoObj.Topic_Number != 0)
            {
                return ParseForEdit(topicDtoObj);
            }
            else if(topicDtoObj.Topic_Number == 0)
            {
                return ParseForAdd(topicDtoObj);
            }
            else
            {
                throw new NotSupportedException("Not Supported parse operation");
            }
        }

        #region Parse for add and edit methods

        private Topic ParseForAdd(TopicDTO topicDtoObj)
        {
            Topic topic = new Topic()
            {
                Description = topicDtoObj.Description,
                Topic_Title = topicDtoObj.Topic_Title,
                Blog_Number = topicDtoObj.Blog_Number
            };

            return topic;
        }

        private Topic ParseForEdit(TopicDTO topicDtoObj)
        {
            Topic topic = _unit.TopicItemRepository.Get(i => i.Topic_Number == topicDtoObj.Topic_Number)
                                                   .FirstOrDefault();

            if(topic == null)
            {

            }

            if(topic.Description != topicDtoObj.Description)
            {
                topic.Description = topicDtoObj.Description;
            }

            if(topic.Topic_Title != topicDtoObj.Topic_Title)
            {
                topic.Topic_Title = topicDtoObj.Topic_Title;
            }

            if(topic.Blog_Number != topicDtoObj.Blog_Number)
            {
                topic.Blog_Number = topicDtoObj.Blog_Number;
            }

            return topic;
        }

        #endregion
    }
}
