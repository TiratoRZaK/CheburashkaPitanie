using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public abstract class LocalModel
    {
        private static BinaryFormatter serializer = new BinaryFormatter();
        private static Stream stream;
        public static void Save(LocalModel model)
        {
            string path = Application.StartupPath + "\\Local Data\\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            if (Directory.Exists(path))
            {
                switch (model.GetType().Name)
                {
                    case "Menu":
                        stream = new FileStream(path + "Меню на " + ((Menu)model).DateCreate.ToLongDateString() + ".menu", FileMode.Create);
                        serializer.Serialize(stream, (Menu)model);
                        break;
                    case "ProductArrival": Console.WriteLine("Продукт нахуй"); break;
                    case "Object": Console.WriteLine("Обжект нахуй"); break;
                    default: Console.WriteLine("Хуйня какая-то " + model.GetType().Name); break;
                }
                stream.Close();
            }
        }
    }
}
