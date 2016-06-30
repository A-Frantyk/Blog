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

        public Writes Parse(WritesDTO dtoObj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region parse methods



        #endregion
    }
}
