using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using WPF_ProjectWork.Services.Interfaces;
using Newtonsoft.Json;
using static WPF_ProjectWork.Services.Classes.JsonService;


namespace WPF_ProjectWork.Services.Classes
{
   
   public class JsonService : IJsonService 
    {
        public void Serialize<T>(string path, ObservableCollection<T> list)
        {
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using var streamWriter = new StreamWriter(fileStream);
            string json = JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            streamWriter.Write(json);
        }

        public ObservableCollection<T> Deserialize<T>(string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream);

            string json = streamReader.ReadToEnd();

            var deserializedObject = JsonConvert.DeserializeObject<ObservableCollection<T>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return deserializedObject;
        }
    }
}
