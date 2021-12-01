using System;
using System.IO;

namespace LW13
{
    public static class AAMDirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\");
            string DirInfoLog = "";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (directoryInfo.Exists)
            {
                DirInfoLog = "\n<=========================================== AAMDirInfo ==============================================>" +
                             "\nКоличество файлов:        " + directoryInfo.GetFiles().Length +
                             "\nВремя создания:           " + directoryInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + directoryInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + directoryInfo.Parent.Name;
            }

            if (directoryInfo.Exists)
            {
                Console.WriteLine("\nКоличество файлов: " + directoryInfo.GetFiles().Length);
                Console.WriteLine("\nВремя создания: " + directoryInfo.LastWriteTime);
                Console.WriteLine("\nКол-во поддиректориев: " + directoryInfo.GetDirectories().Length);
                Console.WriteLine("\nРодительский директорий: " + directoryInfo.Parent.Name);
            }
            
            AAMLog.WriteInLog(DirInfoLog);
        }
    }
}