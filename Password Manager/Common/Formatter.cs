using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common
{
    public static class Formatter
    {
        public static bool FormatDrive_CommandLine(char driveLetter, string label = "Key", string fileSystem = "FAT32", bool quickFormat = true, bool enableCompression = false, int? clusterSize = null)
        {/*
            #region args check

            if (!Char.IsLetter(driveLetter))
            {
                return false;
            }
            string drive = driveLetter + ":";
            var di = new DriveInfo(drive);
            if(di.DriveType != DriveType.Removable)
            {
                return false;
            }


            #endregion
            MessageBox.Show("Test" + driveLetter);
            bool success = false;
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = "format.com";
                psi.CreateNoWindow = true; //if you want to hide the window
                psi.WorkingDirectory = Environment.SystemDirectory;
                psi.Arguments = "/FS:" + fileSystem +
                                             " /Y" +
                                             " /V:" + label +
                                             (quickFormat ? " /Q" : "") +
                                             ((fileSystem == "NTFS" && enableCompression) ? " /C" : "") +
                                             (clusterSize.HasValue ? " /A:" + clusterSize.Value : "") +
                                             " " + drive;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                var formatProcess = Process.Start(psi);
                var swStandardInput = formatProcess.StandardInput;
                swStandardInput.WriteLine();
                formatProcess.WaitForExit();
                success = true;
            }
            catch (Exception) { }*/
            return true;
        }
    }


}
