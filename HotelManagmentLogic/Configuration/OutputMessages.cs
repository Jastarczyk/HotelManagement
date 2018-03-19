using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Configuration
{
    public class OutputMessages
    {
        #region Login/Register output messages

        //Approving messages
        public const string RegisterSuccessfulMessage = "User registered successfully";
        public const string LoginSuccessfulMessage = "Login successful";
        public const string UserInformationValid = "User information - valid";

        //common errors messages (login/register/usernames validation)
        public const string InvalidUserNameSyntax = "Invalid Username, please do not use special characters";
        public const string InvalidPasswordSyntax = "Invalid Password, please do not use special characters";
        public const string UserNameDuplicated = "This Username is already in use";

        public static string InvalidUserName()
        {
            return String.Format("The Username must be between {0} and {1} characters long",
                                                Config.MinimumUserLenght, Config.MaxUserLength);
        }

        public static string InvalidPassword()
        {
            return String.Format("The Password must be between {0} and {1} characters long",
                                                Config.MinimumPasswordLenght, Config.MaxPasswordLength);
        }

        public const string PasswordNoMatch = "Password doesn't match";
        public const string NoUserInDataBase = "Username don't exists";
        public const string IncorrectPassowrd = "Incorrect password";
        public const string InternalError = "Internal error. If problem will repeat, concact with support";
        public const string FailedAddedToDatabase = "Can't add data to database";
        public const string InvalidArgumentName = "Invalid Argument Name: ";
        public const string MissingArgumentsMessage = "Please fill all information";

        #endregion

        #region Database strings
        //DataBase confirmation
        public const string DataBaseInsertSuccess = "Data inserted successfully";

        //DataBase errors
        public const string DataBaseConnectionError = "Cannot connect to database";
        public const string DataBaseInsertFailed = "Cannot insert data to database";
        #endregion

        #region Addition forms/controls messages

        public const string QuestionApplicationExit = "Exit application ?";
        public const string ApplicationClosingMessage = "Application closing";
        public const string RoomDisplayMessage = "Room number: ";

        #endregion
    }
}
