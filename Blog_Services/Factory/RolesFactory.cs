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
    public class RolesFactory : IFactory<RolesDTO, Roles>
    {
        private readonly IUnitOfWork _unit;

        public RolesFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public RolesDTO Create(Roles modelObj)
        {
            if (modelObj == null)
            {

            }

            RolesDTO rolesDTO = new RolesDTO()
            {
                RoleName = modelObj.RoleName
            };

            return rolesDTO;
        }

        public async Task<Roles> Parse(RolesDTO dtoObj)
        {
            if(dtoObj == null)
            {

            }

            if(dtoObj.RoleID != 0)
            {
                return await ParseForEdit(dtoObj);
            }
            else if(dtoObj.RoleID == 0)
            {
                return ParseForAdd(dtoObj);
            }
            else
            {
                throw new NotSupportedException("Cannot add new role!!!");
            }
        }
        

        #region add and edit parse methods

        private Roles ParseForAdd(RolesDTO dtoObj)
        {
            Roles role = new Roles()
            {
                RoleName = dtoObj.RoleName
            };

            return role;
        }

        private async Task<Roles> ParseForEdit(RolesDTO dtoObj)
        {
            var item = await _unit.RolesItemRepository.Get(a => a.RoleID == dtoObj.RoleID);

            Roles role = item.FirstOrDefault();

            if(role.RoleName != dtoObj.RoleName)
            {
                role.RoleName = dtoObj.RoleName;
            }

            return role;
        }

        #endregion
    }
}
