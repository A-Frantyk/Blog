using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.Factory
{
    public interface IFactory<TDTO, UModel>
        where TDTO : class
        where UModel : class
    {
        TDTO Create(UModel modelObj);

        Task<UModel> Parse(TDTO dtoObj);
    }
}
