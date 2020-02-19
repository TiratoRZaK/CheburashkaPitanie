using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

namespace Дет.Сад.Питание.Services
{
    public class LoggingService
    {
        public static List<Log> logs { get; set; }

        public static void StartLogging()
        {
            if(File.Exists(MainForm.LogsPath + "\\logs.log"))
            {
                Stream stream = new FileStream(MainForm.LogsPath + "\\logs.log", FileMode.OpenOrCreate);
                logs = new BinaryFormatter().Deserialize(stream) as List<Log>;
                stream.Close();
            }
            else
            {
                logs = new List<Log>();
            }
            AddLog("---Старт программы.");

        }

        public static void StopLogging()
        {
            AddLog("---Остановка программы.");
            Stream stream = new FileStream(MainForm.LogsPath + "\\logs.log", FileMode.Create);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, logs);
            stream.Close();
        }
       
        public static void AddLog( string message, params ActionDescription[] actions)
        {
            logs.Add(new Log(message, actions.ToList()));
        } 
    }
}
