using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog_Services.UnitOfWork;
using Blog_Entity.Model;
using Blog_Services.ModelDTO;

namespace Blog_Services.Factory
{
    public class Writes_Factory : IFactory<WritesDTO, Writes>
    {
        private readonly IUnitOfWork _unit;

        public Writes_Factory(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        #region create methods
        public WritesDTO Create(Writes writes)
        {
            if(writes == null)
            {
                throw new NullReferenceException("Input parameter is NULL!!!");
            }

            var writesDTO = new WritesDTO
            {
                Write_Number = writes.Write_Number,
                Topic_Number = writes.Topic_Number,
                Title = writes.Title,
                Description = writes.Description,
                Author = writes.Author,
                Date = writes.Date,
                Time = writes.Time,

                AuthorFullInfo = LoadUserData(writes.Author).Result,
                Comments = LoadComments(writes.Write_Number).Result,
                Likes = LoadLikes(writes.Write_Number).Result
            };

            return writesDTO;
        }
        
        #endregion

        #region parse methods

        public async Task<Writes> Parse(WritesDTO writesDtoObj)
        {
            if(writesDtoObj.Write_Number != 0)
            {
                return await ParseForEdit(writesDtoObj);
            }
            else if(writesDtoObj.Write_Number == 0)
            {
                return ParseForAdd(writesDtoObj);
            }
            else
            {
                throw new NotSupportedException("Not supported for writes object!!");
            }
        }

        private Writes ParseForAdd(WritesDTO writesDtoObj)
        {
            Writes write = new Writes()
            {
                Topic_Number = writesDtoObj.Topic_Number,
                Title = writesDtoObj.Title,
                Description = writesDtoObj.Description,
                Author = writesDtoObj.Author,
                Date = writesDtoObj.Date,
                Time = writesDtoObj.Time
            };

            return write;
        }

        private async Task<Writes> ParseForEdit(WritesDTO writesDtoObj)
        {
            var item = await _unit.WritesItemRepository.Get(i => i.Write_Number == writesDtoObj.Write_Number);

            Writes write = item.FirstOrDefault();

            if(write == null)
            {

            }

            if(write.Topic_Number != writesDtoObj.Topic_Number)
            {
                write.Topic_Number = writesDtoObj.Topic_Number;
            }

            if(write.Title != writesDtoObj.Title)
            {
                write.Title = writesDtoObj.Title;
            }

            if(write.Description != writesDtoObj.Description)
            {
                write.Description = writesDtoObj.Description;
            }

            if(write.Author != writesDtoObj.Author)
            {
                write.Author = writesDtoObj.Author;
            }
            if (write.Date != writesDtoObj.Date)
            {
                write.Date = writesDtoObj.Date;
            }

            if(write.Time != writesDtoObj.Time)
            {
                write.Time = writesDtoObj.Time;
            }

            return write;
        }

        #endregion

        #region LoadAddData

        private async Task<UserDTO> LoadUserData(int id)
        {
            if(id != 0)
            {
                var loadedItems = await _unit.UserItemRepository.Get(a => a.User_Number == id);
                var userFactory = new User_Factory(_unit);
                var result = userFactory.Create(loadedItems.FirstOrDefault());

                return result;
            }
            else
            {
                return null;
            }
        }

        private async Task<List<CommentsDTO>> LoadComments(int? writeId)
        {
            if(writeId != 0 && writeId != null)
            {
                var loadedItem = await _unit.CommentsItemRepository.Get(a => a.Writes_Number == writeId);
                var commentsFactory = new CommentsFactory(_unit);
                var result = loadedItem.Select(a => commentsFactory.Create(a));

                return result.ToList();
            }
            else
            {
                return null;
            }
        }
        
        private async Task<List<LikesDTO>> LoadLikes(int? writeId)
        {
            if(writeId != 0 && writeId != null)
            {
                var loadedData = await _unit.LikesItemRepository.Get(a => a.Write_Number == writeId);
                var likesFactory = new LikesFactory(_unit);
                var result = loadedData.Select(a => likesFactory.Create(a));

                return result.ToList();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
