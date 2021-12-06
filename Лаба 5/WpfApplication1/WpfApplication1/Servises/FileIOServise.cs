using System.ComponentModel;
using System.IO;
using Lb_5;
using Newtonsoft.Json;

namespace WpfApplication1.Servises
{
    
    public class FileIOServise
    {
        private readonly string PATH;

        public FileIOServise(string path)
        {
            PATH = path;
        }
        
        public BindingList<student_performance> LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<student_performance>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<student_performance>>(fileText);
            }
        }

        public void SaveData(object studentDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(studentDataList);
                writer.Write(output);
            }
        }
    }
}