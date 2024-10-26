using Newtonsoft.Json;

namespace AirportTicketBookingSystem.Services
{
    public class FileService
    {
        public virtual void SaveToFile<T>(string filePath, List<T> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public virtual void SaveToFile<T>(string filePath, T data)
        {
            List<T> list = new List<T> { data };
            SaveToFile(filePath, list);
        }

        public virtual List<T> LoadFromFile<T>(string filePath) 
        {
            if (!File.Exists(filePath)) { 
                return new List<T> {};
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }


    }
}
