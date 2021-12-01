using System;
using System.IO;

namespace LW13
{
    public static class AAMFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\aamlogfile.txt");
            string fileInfoLog = "";
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfoLog = "\n<=========================================== AAMFileInfo =============================================>" +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length + " KB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;
            }
            
            if (fileInfo.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInfo.Name);
                Console.WriteLine("Время создания: {0}", fileInfo.CreationTime);
                Console.WriteLine("Размер: {0}", fileInfo.Length);
            }
            
            AAMLog.WriteInLog(fileInfoLog);
        }
    }
}