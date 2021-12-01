using System;

namespace LW13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AAMLog.WriteLogInfo();
                
                AAMDiskInfo.DiskInfo();
                
                AAMFileInfo.GetFileInfo();
                
                AAMDirInfo.GetDirInfo();
                
                AAMFileManager.AAMFiles();
                AAMFileManager.MakeArchive();
                AAMFileManager.AAMInspect();

                AAMLog.ReadLog();
                AAMLog.SearchLog();
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Директорий не найден: " + e.StackTrace);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Файл уже существует: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}