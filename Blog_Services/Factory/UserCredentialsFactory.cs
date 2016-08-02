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
    public class UserCredentialsFactory : IFactory<UserCredentialsDTO, UserCredentials>
    {
        private readonly IUnitOfWork _unit;

        public UserCredentialsFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public UserCredentialsDTO Create(UserCredentials userCredentials)
        {
            if(userCredentials == null)
            {

            }

            var userCredentialsDTO = new UserCredentialsDTO()
            {
                UserID = userCredentials.UserID,
                Login = userCredentials.Login,
                Password = userCredentials.Password
            };

            return userCredentialsDTO;
        }

        public async Task<UserCredentials> Parse(UserCredentialsDTO dtoObj)
        {
            if(dtoObj == null)
            {

            }

            if (dtoObj.UserID != 0)
            {
                return await ParseForEdit(dtoObj);
            }
            else if(dtoObj.UserID == 0)
            {
                return ParseForAdd(dtoObj);
            }
            else
            {
                throw new NotSupportedException("Cannot add new credentials!!!");
            }
        }


        #region Parse methods for add and edit

        private UserCredentials ParseForAdd(UserCredentialsDTO dtoObj)
        {
            UserCredentials credentionals = new UserCredentials()
            {
                Login = dtoObj.Login,
                Password = dtoObj.Password
            };

            return credentionals;
        }

        private async Task<UserCredentials> ParseForEdit(UserCredentialsDTO dtoObj)
        {
            var item = await _unit.UserCredentialsItemRepository.Get(a => a.UserID == dtoObj.UserID);

            UserCredentials credentials = item.FirstOrDefault();

            if(credentials == null)
            {

            }

            if(credentials.Login != dtoObj.Login)
            {
                credentials.Login = dtoObj.Login;
            }

            if(credentials.Password != dtoObj.Password)
            {
                credentials.Password = dtoObj.Password;
            }

            return credentials;
        }

        #endregion
    }
}
