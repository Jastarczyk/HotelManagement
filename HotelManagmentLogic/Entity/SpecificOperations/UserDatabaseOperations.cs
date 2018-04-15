using HotelManagmentLogic.Entity.CommonOperations;
using HotelManagmentLogic.Entity.DatabaseConfig;
using HotelManagmentLogic.Enums;
using HotelManagmentLogic.GuestsControlLogic;
using HotelManagmentLogic.Models.Administration;
using System;
using System.Linq;


namespace HotelManagmentLogic.Entity.SpecificOperations
{
    public class UserDatabaseOperations : DatabaseOperations
    {
        public static User GetUserByUsername(string username)
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    return hotelContext.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
                }
            }
            catch(Exception)
            {
                return new User();
            }
        }

        public static AddToDatabaseResult ChangeUserPermissions(User user, UserType userType)
        {
            try
            {
                using (HotelContext hotelContext = new HotelContext())
                {
                    hotelContext.Users.Find(user.Username).UserType = userType;
                    hotelContext.SaveChanges();
                }

                return BuildOperationResult(true, Configuration.OutputMessages.DataBaseInsertSuccess);
            }
            catch (Exception ex)
            {
                return BuildOperationResult(false, Configuration.OutputMessages.DataBaseInsertFailed, ex);
            }
        }
    }
}
