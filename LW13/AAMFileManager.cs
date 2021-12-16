using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LW13
{
    public static class AAMFileManager
    {
        public static void AAMInspect()
        {
            string classLogInfo = "\n<======================================   AAMFileManager   ===========================================>\n";
            string inspectLog = "";

            DriveInfo[] drives = DriveInfo.GetDrives();
            DirectoryInfo directory = new DirectoryInfo(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13");

            directory.Create();
            directory.CreateSubdirectory(@"AAMInspect");

            DirectoryInfo AAMInspectFiles = new DirectoryInfo(Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMFiles"));
            if (AAMInspectFiles.Exists)
                AAMInspectFiles.Delete(true);

            string filePath = Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\aamdirinfo.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            using (StreamWriter sw = fileInfo.CreateText())
            {
                sw.WriteLine("Happy New Year!");
                sw.Close();
            }


            string renamePath = Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\aamdirinfoRENAMED.txt");
            FileInfo renameBuf = new FileInfo(renamePath);
            renameBuf.Delete();

            fileInfo.CopyTo(renamePath);
            fileInfo.Delete();


            DirectoryInfo inspectDirInfo = new DirectoryInfo(Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect"));
            string files = "";
            for (int i = 0; i < inspectDirInfo.GetFiles().Length; i++)
                files += inspectDirInfo.GetFiles()[i].Name + "; ";

            string directories = "";
            for (int i = 0; i < inspectDirInfo.GetDirectories().Length; i++)
                directories += inspectDirInfo.GetDirectories()[i];

            if (inspectDirInfo.Exists)
                inspectLog = classLogInfo +
                             "\nФайлы:                    " + files +
                             "\nПоддиректории:            " + directories +
                             "\nРодительский директорий:  " + inspectDirInfo.Parent.Name;


            AAMLog.WriteInLog(inspectLog);
        }

        public static void AAMFiles()
        {
            string AAMFilesPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMFiles");
            string AAMInspectFilesPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMFiles");
            string AAMUnzipPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMUnzip");
            string ZipPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMFiles.zip");
            string musicPath = 
                Path.GetFullPath(@"D:\Music");

            DirectoryInfo AAMFiles = new DirectoryInfo(AAMFilesPath);
            DirectoryInfo AAMInspectFiles = new DirectoryInfo(AAMInspectFilesPath);
            DirectoryInfo AAMUnzip = new DirectoryInfo(AAMUnzipPath);
            
            // Создаем папки ,если их нет
            if (!AAMFiles.Exists)
            {
                AAMFiles.Create();
            }

            if (AAMUnzip.Exists)
            {
                AAMUnzip.Delete(true);
            }

            if (File.Exists(ZipPath))
            {
                File.Delete(ZipPath);
            }

            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);
            FileInfo[] fileMusic = musicDirInfo.GetFiles();
            foreach (var file in fileMusic)
            {
                if (file.Extension == ".mp3" || file.Extension == ".mp4")
                {
                    file.CopyTo(Path.Combine(AAMFilesPath, file.Name), true);
                }
            }

            if (AAMInspectFiles.Exists)
            {
                AAMInspectFiles.Delete(true);
            }

            if (AAMFiles.Exists)
            {
                AAMFiles.MoveTo(AAMInspectFilesPath);
            }

        }

        public static void MakeArchive()
        {
            string AAMFilesPath = 
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMFiles");
            string AAMInspectFilesPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMFiles");
            string AAMInspectUnzipPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMUnzip");
            string ZipPath =
                Path.GetFullPath(@"D:\Универ 2 курс\Университет 3 семестр\ООП\LW13\LW13\AAMInspect\AAMFiles.zip");

            // Архивируем
            DirectoryInfo AAMFiles = new DirectoryInfo(AAMFilesPath);
            ZipFile.CreateFromDirectory(AAMInspectFilesPath, ZipPath);


            // Если остался Inspect(Files), то удаляем его
            DirectoryInfo AAMInspectFiles = new DirectoryInfo(AAMInspectFilesPath);
            if (AAMInspectFiles.Exists)
            {
                AAMInspectFiles.Delete(true);
            }

            // Создаем папку для архивации
            DirectoryInfo AAMInspectUnzip = new DirectoryInfo(AAMInspectUnzipPath);
            if (AAMInspectUnzip.Exists)
            {
                AAMInspectUnzip.Delete(true);
            }
            AAMInspectUnzip.Create();

            // Разархивация
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                var result = from entry in archive.Entries
                    where !String.IsNullOrEmpty(entry.Name)
                    select entry;
                foreach (var entry in result)
                {
                    entry.ExtractToFile(Path.Combine(AAMInspectUnzipPath, entry.Name));
                }
            }

        }
    }
}