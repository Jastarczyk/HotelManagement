using HotelManagmentLogic.Builders;
using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Entity;
using HotelManagmentLogic.LoginScreenLogic.Abstract;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HotelManagmentLogic.LoginScreenLogic
{
    public class UserRegister
    {
        public static RegistrationResult NewUser(string userName, string password, string confirmedPassword, string name, string surname)
        {
            if (!password.Equals(confirmedPassword))
            {
                return BuildRegistrationResult(registrationStatus: false, 
                                                          message: OutputMessages.PasswordNoMatch);
            }

            var localUser = new NewUserBuilder().SetUsername(userName)
                                                .SetPassword(password)
                                                .SetName(name)
                                                .SetSurname(surname)
                                                .Build();

            Tuple<bool, string> userValidation = CheckNewUserValidation(localUser);

            if (!userValidation.Item1)
            {
                return BuildRegistrationResult(registrationStatus: false, 
                                                          message: userValidation.Item2);
            }
            try
            {
                return AddUserToDataBase(localUser);
            }

            catch (Exception ex)
            {
                return BuildRegistrationResult(registrationStatus: false,
                                                          message: ex.Message);
            }
        }

        private static RegistrationResult AddUserToDataBase(UserModel user)
        {
            using (var holetContext = new HotelContext())
            {
                bool duplacateUserCheck = holetContext.Users.Any(x => x.Name.Equals(user.Username));

                if(duplacateUserCheck)
                {
                    return BuildRegistrationResult(registrationStatus: false,
                                                       message: OutputMessages.UserNameDuplicated);
                }

                holetContext.Users.Add(user);
                holetContext.SaveChanges();

                return BuildRegistrationResult(registrationStatus: true,
                                                          message: OutputMessages.RegisterSuccesfulMessage);
            }
        }

        /// <summary>
        /// Check user input validation. Returns Item1 as validation status, Item2 as output message.
        /// </summary>
        private static Tuple<bool, string> CheckNewUserValidation(UserModel user)
        {
            if (user.Username.Length < Config.MinimumUserLenght || user.Username.Length > Config.MaxUserLength)
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidUserName());
            }

            if (user.Password.Length < Config.MinimumPasswordLenght || user.Password.Length > Config.MaxPasswordLength)
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidPassword());
            }

            if (!Regex.IsMatch(user.Username, Config.SpecialCharactersPattern))
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidUserNameSyntax);
            }

            if (!Regex.IsMatch(user.Password, Config.SpecialCharactersPattern))
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidPasswordSyntax);
            }

            return new Tuple<bool, string>(true, OutputMessages.UserInformationValid);
        }

        private static RegistrationResult BuildRegistrationResult(bool registrationStatus, string message)
        {
            return new RegistrationResult()
            {
                RegistrationSuccessful = registrationStatus,
                RegistrationMessage = message
            };
        }
    }
}
