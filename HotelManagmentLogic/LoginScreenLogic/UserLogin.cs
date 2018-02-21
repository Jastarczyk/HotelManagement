using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.LoginScreenLogic.Abstraction;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic
{
    public class UserLogin : UserValidation
    {
        public LoginResult Login(string userName, string password)
        {
            var userValidation = CheckUserValidation(userName, password);

            if (!userValidation.Item1)
            {
                return BuildAccessUserActionResult<LoginResult>(userActionStatus: false, userActionMessage: userValidation.Item2);
            }

            try
            {
                using (var hotelContext = new HotelContext())
                {
                    UserModel user = hotelContext.Users.Where(x => x.Username.Equals(userName)).ToList().FirstOrDefault();


                    if (user == null)
                    {
                        return BuildAccessUserActionResult<LoginResult>( userActionStatus: false, 
                                                                         userActionMessage: OutputMessages.NoUserInDataBase);
                    }

                    if (!user.Password.Equals(password))
                    {
                        return BuildAccessUserActionResult<LoginResult>( userActionStatus: false, 
                                                                         userActionMessage: OutputMessages.IncorrectPassowrd);
                    }

                    return UserLoginSuccessfullResult(user);
                }
            }
            catch (Exception)
            {
                return BuildAccessUserActionResult<LoginResult>(userActionStatus: false, userActionMessage: OutputMessages.InternalError);
            }
        }

        private LoginResult UserLoginSuccessfullResult(UserModel user)
        {
            return new LoginResult()
            {
                LoggedUser = user,
                LoginTime = DateTime.Now,
                UserAccessActionMessage = OutputMessages.LoginSuccessfulMessage,
                UserAccessActionStatus = true
            };
        }
    }
}
