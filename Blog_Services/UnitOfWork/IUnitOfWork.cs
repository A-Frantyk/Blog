using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog_Entity.Model;

namespace Blog_Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Blog> BlogItemRepository { get; }

        IGenericRepository<Topic> TopicItemRepository { get; }

        IGenericRepository<Writes> WritesItemRepository { get; }

        IGenericRepository<Comments> CommentsItemRepository { get; }

        IGenericRepository<Likes> LikesItemRepository { get; }

        IGenericRepository<User> UserItemRepository { get; }
    }
}
