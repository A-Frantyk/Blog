using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog_Entity;
using Blog_Entity.Model;

namespace Blog_Services.UnitOfWork
{
    public class UnitOfWork_Pattern : IUnitOfWork
    {
        private BlogEntityContext context = new BlogEntityContext();

        #region fields declaration

        private IGenericRepository<Blog> blogItemRepository;
        private IGenericRepository<Writes> writesItemsRepository;
        private IGenericRepository<Comments> commentsItemRepository;
        private IGenericRepository<Likes> likesItemsRepository;
        private IGenericRepository<Topic> topicItemRepository;
        private IGenericRepository<User> userItemRepository;

        #endregion

        #region IUnitOfWork implementation

        public IGenericRepository<Blog> BlogItemRepository
        {
            get
            {
                if (this.blogItemRepository == null)
                {
                    this.blogItemRepository = new GenericRepository<Blog>(context);
                }

                return blogItemRepository;
            }
        }

        public IGenericRepository<Topic> TopicItemRepository
        {
            get
            {
                if(this.topicItemRepository == null)
                {
                    this.topicItemRepository = new GenericRepository<Topic>(context);
                }

                return topicItemRepository;
            }
        }

        public IGenericRepository<Writes> WritesItemRepository
        {
            get
            {
                if(this.writesItemsRepository == null)
                {
                    this.writesItemsRepository = new GenericRepository<Writes>(context);
                }

                return writesItemsRepository;
            }
        }

        public IGenericRepository<Comments> CommentsItemRepository
        {
            get
            {
                if(this.commentsItemRepository == null)
                {
                    this.commentsItemRepository = new GenericRepository<Comments>(context);
                }

                return commentsItemRepository;
            }
        }

        public IGenericRepository<Likes> LikesItemRepository
        {
            get
            {
                if(this.likesItemsRepository == null)
                {
                    this.likesItemsRepository = new GenericRepository<Likes>(context);
                }

                return likesItemsRepository;
            }
        }

        public IGenericRepository<User> UserItemRepository
        {
            get
            {
                if(this.userItemRepository == null)
                {
                    this.userItemRepository = new GenericRepository<User>(context);
                }

                return userItemRepository;
            }
        }

        #endregion

    }
}
