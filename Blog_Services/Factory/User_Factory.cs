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
    public class User_Factory : IFactory<UserDTO, User>
    {
        private readonly IUnitOfWork _unit;

        public User_Factory(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public UserDTO Create(User userObj)
        {
            if(userObj == null)
            {

            }

            var userDTO = new UserDTO()
            {
                User_Number = userObj.User_Number,
                Name = userObj.Name,
                Last_Name = userObj.Last_Name,
                Age = userObj.Age,
                Education = userObj.Education,
                Mobile_Phone = userObj.Mobile_Phone,
                Short_Information = userObj.Short_Information,
                Facebook_Link = userObj.Facebook_Link,
                Vk_Link = userObj.Vk_Link,
                Mail_Link = userObj.Mail_Link
            };

            return userDTO;
        }

        public User Parse(UserDTO dtoObj)
        {
            throw new NotImplementedException();
        }
    }
}
