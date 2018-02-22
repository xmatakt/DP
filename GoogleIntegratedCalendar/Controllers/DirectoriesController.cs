using ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DatabaseCommunicator.Model;
namespace EZKO.Controllers
{
    /// <summary>
    /// Controller to control EZKO directory structure
    /// </summary>
    public class DirectoriesController
    {
        #region Ezko

        /// <summary>
        /// Creates the EZKO root folder (if doesn't exist) and returns path to that folder
        /// </summary>
        /// <returns>Path to the root EZKO folder</returns>
        private static string GetRootFolder()
        {
            string result = GlobalSettings.EzkoRootFolderPath;

            if(!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        /// <summary>
        /// Creates the EZKO forms folder (if doesn't exist) and returns path to that folder
        /// </summary>
        /// <returns>Path to the EZKO forms folder</returns>
        public static string GetFormsFolder()
        {
            string result = GetRootFolder() + @"\Formulare";

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        #endregion

        #region Users
        /// <summary>
        /// Returns the root folder for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        public static string GetUserRootFolder(string userName)
        {
            string result = GlobalSettings.UserRootFolderPath + @"\" + userName;

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        /// <summary>
        /// Returns the image folder for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        public static string GetUserImageFolder(string userName)
        {
            string result = GetUserRootFolder(userName) + @"\images";

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
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
        #endregion

        #region Patients
        /// <summary>
        /// Returns the root folder for supplied patient
        /// </summary>
        /// <param name="patient">Supplied patient</param>
        public static string GetPatientRootFolder(Patient patient)
        {
            string result = GlobalSettings.PatientsRootFolderPath + @"\" + patient.Name + "_" + patient.Surname + "_" + patient.ID;

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        /// <summary>
        /// Returns the image folder for supplied patient
        /// </summary>
        /// <param name="patient">Supplied patient</param>
        public static string GetPatientImageFolder(Patient patient)
        {
            string result = GetPatientRootFolder(patient) + @"\images";

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        /// <summary>
        /// Returns the documents folder for supplied patient
        /// </summary>
        /// <param name="patient">Supplied patient</param>
        public static string GetPatientDocumentsFolder(Patient patient)
        {
            string result = GetPatientRootFolder(patient) + @"\documents";

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        /// <summary>
        /// Returns path to supplied image in the EZKO directory structure for supplied user
        /// </summary>
        /// <param name="userName">Supplied user</param>
        /// <param name="imagePath">Original image path</param>
        //public static string GetEzkoUserImagePath(string userName, string imagePath)
        //{
        //    if (imagePath == null)
        //        return null;

        //    string imageName = Path.GetFileName(imagePath);
        //    return GetUserImageFolder(userName) + @"\" + imageName;
        //}

        /// <summary>
        /// Creates the EZKO directory structure for the supplied patient
        /// </summary>
        /// <param name="patient">Patient whose directory structure has to be created</param>
        /// <returns>Value indicating wheter the directory structure creation was succesful</returns>
        public static bool CreatePatientFolderStructure(Patient patient)
        {
            bool result = true;

            try
            {
                var path = GetPatientImageFolder(patient);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path = GetPatientDocumentsFolder(patient);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                BasicMessagesHandler.LogException(e);
                result = false;
            }

            return result;
        }
        #endregion

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
                {
                    bool copy = true;
                    if (File.Exists(destinationFileName))
                    {
                        try
                        {
                            File.Delete(destinationFileName);
                        }
                        //if user choose the same image as image which is currently used, can't delete that file,
                        //because is used by another process
                        catch (IOException e)
                        {
                            copy = false;
                        }
                    }
                    
                    //if file was succesfully deleted or did not exists yet
                    if(copy)
                        File.Copy(sourceFileName, destinationFileName);
                }
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

        public static bool CopyToDocumentsFolder(Patient patient, string filePath)
        {
            bool result = true;

            if (File.Exists(filePath))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string destinationPath = GetPatientDocumentsFolder(patient) + @"\" + fileInfo.Name;
                    if(!File.Exists(destinationPath))
                        File.Copy(filePath, destinationPath);
                }
                catch (Exception e)
                {
                    BasicMessagesHandler.LogException(e);
                    result = false;
                }
            }

            return result;
        }

        public static bool RemoveFile(string path)
        {
            bool result = true;

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}
