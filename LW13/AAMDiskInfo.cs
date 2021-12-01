using System;
using System.IO;

namespace LW13
{
    public static class AAMDiskInfo
    {
        public static void DiskInfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string DiskInfo = "";
            
            DiskInfo = "\n<=========================================== AAMDisk (C:) =============================================>" +
                       "\nИмя диска:                " + allDrives[0].Name +
                       "\nФайловая система:         " + allDrives[0].DriveFormat +
                       "\nДоступное место:          " + allDrives[0].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + allDrives[0].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + allDrives[0].VolumeLabel + "\n" +

                       "\n<=========================================== AAMDisk (D:) =============================================>" +
                       "\nИмя диска:                " + allDrives[1].Name +
                       "\nФайловая система:         " + allDrives[1].DriveFormat +
                       "\nДоступное место:          " + allDrives[1].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + allDrives[1].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + allDrives[1].VolumeLabel;

            foreach (var item in allDrives)
            {
                Console.WriteLine("Drive {0}", item.Name);
                Console.WriteLine("  Drive type: {0}", item.DriveType);
                if (item.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", item.VolumeLabel);
                    Console.WriteLine("  File system: {0}", item.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        item.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        item.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        item.TotalSize);
                }
            }

            AAMLog.WriteInLog(DiskInfo);
        }
    }
}