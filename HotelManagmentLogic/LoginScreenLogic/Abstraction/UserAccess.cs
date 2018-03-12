using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.LoginScreenLogic.UserAccessActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelManagmentLogic.LoginScreenLogic.Abstraction
{
    public abstract class UserAccess
    {
        /// <summary>
        /// Check user input validation. Returns Item1 as validation status, Item2 as output message.
        /// </summary>
        protected Tuple<bool, string> CheckUserValidation(string userName, string password)
        {
            if (userName.Length < Config.MinimumUserLenght || userName.Length > Config.MaxUserLength)
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidUserName());
            }

            if (password.Length < Config.MinimumPasswordLenght || password.Length > Config.MaxPasswordLength)
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidPassword());
            }

            if (!Regex.IsMatch(userName, Config.SpecialCharactersPattern))
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidUserNameSyntax);
            }

            if (!Regex.IsMatch(password, Config.SpecialCharactersPattern))
            {
                return new Tuple<bool, string>(false, OutputMessages.InvalidPasswordSyntax);
            }

            return new Tuple<bool, string>(true, OutputMessages.UserInformationValid);
        }

        protected virtual AddToDatabaseResult BuildOperationResult(string message, bool status, Exception exception = null, object obj = null)
        {
            return new AddToDatabaseResult()
            {
                Message = message,
                OperationSuccess = status,
                PossibleException = exception
            };
        }
    }
}
