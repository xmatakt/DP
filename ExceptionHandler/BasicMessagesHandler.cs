using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ExceptionHandler
{
    /// <summary>
    /// Class for exception handling anlogging
    /// </summary>
    public static class BasicMessagesHandler
    {
        private static string logFilePath = "errorLog.log";

        public static void SetLogFilePath(string path)
        {
            logFilePath = path;
            File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
        }

        /// <summary>
        /// Dispalys error message on the screen and logs the exception into text file
        /// </summary>
        /// <param name="message">Message to show</param>
        /// <param name="ex">Exception to log</param>
        public static void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show(message, "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogException(ex);
        }

        /// <summary>
        /// Dispalys error message on the screen 
        /// </summary>
        /// <param name="message">Message to show</param>
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Dispalys error message on the screen 
        /// </summary>
        /// <param name="message">Message to show</param>
        public static void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Logs the exception into text file
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public static void LogException(Exception ex)
        {
            try
            {
                StreamWriter writer = new StreamWriter(logFilePath, true);
                writer.WriteLine("####### " + DateTime.Now + " #######");

                writer.WriteLine(ex.ToString());
                writer.WriteLine("");
                writer.Flush();
                writer.Close();
            }
            catch(Exception e)
            {
                ShowErrorMessage(e.ToString());
            }
        }

        public static DialogResult ShowWarningMessage(string question)
        {
            return MessageBox.Show(question, "Upozornenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
