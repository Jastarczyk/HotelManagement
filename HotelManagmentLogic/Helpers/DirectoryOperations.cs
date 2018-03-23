using HotelManagmentLogic.Configuration;
using HotelManagmentLogic.Models.Acommodation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Helpers
{
    public class DirectoryOperations
    {
        public static List<string> GetCurrentRoomImagesURL(Room room)
        {
            List<string> images = new List<string>();

            try
            {
                string imagesPath = Directory.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + Config.RoomsImagePath + room.RoomNumber.ToString()) ?
                                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + Config.RoomsImagePath + room.RoomNumber.ToString()
                                   :  string.Empty;

                if (string.IsNullOrEmpty(imagesPath))
                {
                    throw new FileNotFoundException();
                }

                Directory.GetFiles(imagesPath).ToList().ForEach((x) =>
                {
                    if (Config.PossibleImageFileExtension.Contains(Path.GetExtension(x)))
                    {
                        images.Add(x);
                    }

                });
            }
            catch (FileNotFoundException ex)
            {
                Logger.ErrorLogger.AddLog(new Logger.ErrorLogger.Error(ex));
                return new List<string>();
            }

            return images;
        }   
    }
}
