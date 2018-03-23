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
                string imagesPath = Directory.Exists(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\Img\Rooms\Room" + room.RoomNumber.ToString()) ?
                                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\Img\Rooms\Room" + room.RoomNumber.ToString()
                                   : throw new FileNotFoundException();

                string[] foundedFiles = Directory.GetFiles(imagesPath);

                images = foundedFiles.Where(x => Path.GetExtension(x).Equals(".jpeg")).ToList();
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
