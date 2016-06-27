using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Services.UnitOfWork
{
    public interface IAdmin<TEntity>
        where TEntity : class
    {
        void Add();
        void Delete();
        void Insert();
        TEntity Get();
        TEntity GetByID(int id);
        void Edit(int id);
    }
}
