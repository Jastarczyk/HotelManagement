using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.LoginScreenLogic.Abstraction;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Linq;

namespace HotelManagmentLogic.LoginScreenLogic
{
    public class UserRegister : UserValidation
    {
        public RegistrationResult NewUser(string userName, string password, string confirmedPassword, string name, string surname)
        {
            if (!password.Equals(confirmedPassword))
            {
                return BuildAccessUserActionResult<RegistrationResult>( userActionStatus: false,
                                                                        userActionMessage: OutputMessages.PasswordNoMatch);
            }

            var localUser = new NewUserBuilder().SetUsername(userName)
                                                .SetPassword(password)
                                                .SetName(name)
                                                .SetSurname(surname)
                                                .Build();

            Tuple<bool, string> userValidation = CheckUserValidation(localUser.Name, localUser.Password);

            if (!userValidation.Item1)
            {
                return BuildAccessUserActionResult<RegistrationResult>( userActionStatus: false,
                                                                        userActionMessage: userValidation.Item2);
            }
            try
            {
                return AddUserToDataBase(localUser);
            }

            catch (Exception)
            {
                return BuildAccessUserActionResult<RegistrationResult>( userActionStatus: false,
                                                                        userActionMessage: OutputMessages.InternalError);
            }
        }

        private RegistrationResult AddUserToDataBase(UserModel user)
        {
            using (var holetContext = new HotelContext())
            {
                bool duplacateUserCheck = holetContext.Users.Any(x => x.Name.Equals(user.Username));

                if(duplacateUserCheck)
                {
                    return BuildAccessUserActionResult<RegistrationResult>( userActionStatus: false,
                                                                            userActionMessage: OutputMessages.UserNameDuplicated);
                }

                holetContext.Users.Add(user);
                holetContext.SaveChanges();

                return BuildAccessUserActionResult<RegistrationResult>( userActionStatus: true,
                                                                        userActionMessage: OutputMessages.RegisterSuccessfulMessage);
            }
        }
    }
}
