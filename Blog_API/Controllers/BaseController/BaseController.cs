using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Blog_Entity;
using Blog_Services.UnitOfWork;
using Blog_Services.ModelDTO;
using Blog_Services.Factory;

namespace Blog_API.Controllers.BaseController
{
    public class BaseController : ApiController
    {
        private IUnitOfWork _unit;
        private WritesDTO_Factory _writesFactory;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
            _writesFactory = new WritesDTO_Factory(_unit);
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unit;
            }
        }

        public WritesDTO_Factory WritesFactory
        {
            get
            {
                return _writesFactory;
            }
        }
    }
}
