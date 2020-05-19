using DAL.Interfaces;
using DAL.Repositories;
using NLog;
using System.IO;

namespace BLL.Services
{
    public class ImportExportService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private string startupPath;
        private IUnitOfWork DB;

        public ImportExportService(IUnitOfWork DB, string startupPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
        }

        public bool Export(string path)
        {
            try
            {
                DirectoryCopy(startupPath + "\\Local Data\\", path + "\\Local Data\\");
                File.Copy(startupPath + "\\CheburashkaDB.db3", path + "\\CheburashkaDB.db3");
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Ошибка выполнения экспорта в дерикторию: " + path + "\n" + ex.Message);
                return false;
            }
            return true;
        }

        public bool Import(string path)
        {
            try
            {
                DirectoryCopy(path + "\\Local Data\\", startupPath + "\\Local Data\\");
                File.Copy(path + "\\CheburashkaDB.db3", startupPath + "\\CheburashkaDB.db3", true);
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Ошибка выполнения импорта из дериктории: " + path);
                return false;
            }
            if ((DB = EFUnitOfWork.GetInstance()) == null)
            {
                logger.Fatal("Невозможно подключиться к базе данных.");
                return false;
            }
            return true;
        }

        void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Получить подкаталоги для указанного каталога.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // Если целевой каталог не существует, создайте его.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Получите файлы в каталоге и скопируйте их в новое место.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // При копировании подкаталогов, скопируйте их и их содержимое в новое место.
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }
    }
}
