using ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO.Controllers
{
    /// <summary>
    /// Controller to control EZKO directory structure
    /// </summary>
    public class DirectoriesController
    {

        /// <summary>
        /// Returns the root folder for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        public static string GetUserRootFolder(string userName)
        {
            return GlobalSettings.UserRootFolderPath + @"\" + userName;
        }

        /// <summary>
        /// Returns the image folder for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        public static string GetUserImageFolder(string userName)
        {
            return GetUserRootFolder(userName) + @"\images";
        }

        /// <summary>
        /// Returns path to supplied image in the EZKO directory structure for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        /// <param name="imagePath">Original image path</param>
        public static string GetEzkoUserImagePath(string userName, string imagePath)
        {
            if (imagePath == null)
                return null;

            string imageName = Path.GetFileName(imagePath);
            return GetUserImageFolder(userName) + @"\" + imageName;
        }

        /// <summary>
        /// Creates the EZKO directory structure for the supplied user
        /// </summary>
        /// <param name="userName">User whose directory structure has to be created</param>
        /// <returns>Value indicating wheter the directory structure creation was succesful</returns>
        public static bool CreateUserFolderStructure(string userName)
        {
            bool result = true;

            try
            {
                var path = GetUserImageFolder(userName);
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch(Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Creates supplied direcotry
        /// </summary>
        /// <param name="path">Directory path</param>
        /// <returns>Value indicating wheter the directory creation was succesful</returns>
        public static bool CreateFolder(string path)
        {
            bool result = true;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }


        /// <summary>
        /// Copy any file type from its surce path to wanted destination
        /// </summary>
        /// <param name="sourceFileName">Source file path</param>
        /// <param name="destinationFileName">Destination file path</param>
        /// <returns>Value indicating whether copying of files were successfull</returns>
        public static bool CopyFile(string sourceFileName, string destinationFileName)
        {
            bool result = true;

            try
            {
                if(sourceFileName != null && destinationFileName != null)
                File.Copy(sourceFileName, destinationFileName);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }

        public static Image GetImage(string path, Image defaultImage)
        {
            if (path != null && System.IO.File.Exists(path))
                return Image.FromFile(path);
            else
                return defaultImage;
        }
    }
}
