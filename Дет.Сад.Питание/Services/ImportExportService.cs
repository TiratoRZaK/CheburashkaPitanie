using System.IO;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Services
{
    public class ImportExportService
    {
        public void Export(string path)
        {
            DirectoryCopy(Application.StartupPath + "\\Local Data\\", path + "\\Local Data\\");
            File.Copy(Application.StartupPath + "\\CheburashkaDB.db3", path + "\\CheburashkaDB.db3");
            MessageBox.Show("Экспорт успешно выполнен");
        }

        public void Import(string path)
        {
            DirectoryCopy(path + "\\Local Data\\", Application.StartupPath + "\\Local Data\\");
            File.Copy(path + "\\CheburashkaDB.db3", Application.StartupPath + "\\CheburashkaDB.db3", true);
            MessageBox.Show("Импорт успешно выполнен");
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
