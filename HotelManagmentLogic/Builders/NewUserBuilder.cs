using HotelManagmentLogic.Enums;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Builders
{
    class NewUserBuilder
    {
        private UserModel user;

        public NewUserBuilder()
        {
            user = new UserModel();
        }

        public NewUserBuilder SetUsername(string username)
        {
            user.Username = username;
            return this;
        }

        public NewUserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public NewUserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }

        public NewUserBuilder SetSurname(string surname)
        {
            user.Surname = surname;
            return this;
        }

        public NewUserBuilder SetUserType(UserType userType)
        {
            user.UserType = userType;
            return this;
        }

        public UserModel Build()
        {
            user.CreatingDate = DateTime.Now;
            user.ID = Guid.NewGuid();

            return user;
        }
    }
}
