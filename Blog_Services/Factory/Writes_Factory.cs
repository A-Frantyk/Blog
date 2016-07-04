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
                Time = writes.Time
            };

            return writesDTO;
        }
        
        #endregion

        #region parse methods

        public Writes Parse(WritesDTO writesDtoObj)
        {
            if(writesDtoObj.Write_Number != 0)
            {
                return ParseForEdit(writesDtoObj);
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

        private Writes ParseForEdit(WritesDTO writesDtoObj)
        {
            Writes write = _unit.WritesItemRepository.Get(i => i.Write_Number == writesDtoObj.Write_Number)
                                                     .FirstOrDefault();

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
    }
}
