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

        public async Task<User> Parse(UserDTO userDtoObj)
        {
            if(userDtoObj == null)
            {

            }

            if(userDtoObj.User_Number != 0)
            {
                return await ParseForEdit(userDtoObj);
            }
            else if(userDtoObj.User_Number == 0)
            {
                return ParseForAdd(userDtoObj);
            }
            else
            {
                throw new NotSupportedException("Not supported for users!");
            }
        }

        #region Parse for add and edit methods

        private User ParseForAdd(UserDTO userDtoObj)
        {
            User user = new User()
            {
                Name = userDtoObj.Name,
                Last_Name = userDtoObj.Last_Name,
                Age = userDtoObj.Age,
                Education = userDtoObj.Education,
                Mobile_Phone = userDtoObj.Mobile_Phone,
                Short_Information = userDtoObj.Short_Information,
                Facebook_Link = userDtoObj.Facebook_Link,
                Vk_Link = userDtoObj.Vk_Link,
                Mail_Link = userDtoObj.Mail_Link
            };

            return user;
        }

        private async Task<User> ParseForEdit(UserDTO userDtoObj)
        {
            var item = await _unit.UserItemRepository.Get(i => i.User_Number == userDtoObj.User_Number);

            User user = item.FirstOrDefault();

            if(user == null)
            {

            }

            if(user.Name != userDtoObj.Name)
            {
                user.Name = userDtoObj.Name;
            }

            if(user.Last_Name != userDtoObj.Last_Name)
            {
                user.Last_Name = userDtoObj.Last_Name;
            }

            if(user.Age != userDtoObj.Age)
            {
                user.Age = userDtoObj.Age;
            }

            if(user.Education != userDtoObj.Education)
            {
                userDtoObj.Education = userDtoObj.Education;
            }

            if(user.Mobile_Phone != userDtoObj.Mobile_Phone)
            {
                user.Mobile_Phone = userDtoObj.Mobile_Phone;
            }

            if(user.Facebook_Link != userDtoObj.Facebook_Link)
            {
                user.Facebook_Link = userDtoObj.Facebook_Link;
            }

            if(user.Vk_Link != userDtoObj.Vk_Link)
            {
                user.Vk_Link = userDtoObj.Vk_Link;
            }

            if(user.Mail_Link != userDtoObj.Mail_Link)
            {
                user.Mail_Link = userDtoObj.Mail_Link;
            }

            if(user.Short_Information != userDtoObj.Short_Information)
            {
                user.Short_Information = userDtoObj.Short_Information;
            }

            return user;
        }

        #endregion
    }
}
