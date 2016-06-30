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
    public class BaseController<TDTO, UModel> : ApiController
        where TDTO : class
        where UModel : class
    {
        private IUnitOfWork _unit;
        private IFactory<TDTO, UModel> _writesFactory;

        public BaseController(IUnitOfWork unit, IFactory<TDTO, UModel> factoryObj)
        {
            _unit = unit;
            _writesFactory = factoryObj;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unit;
            }
        }

        public IFactory<TDTO, UModel> Factory
        {
            get
            {
                return _writesFactory;
            }
        }
    }
}
