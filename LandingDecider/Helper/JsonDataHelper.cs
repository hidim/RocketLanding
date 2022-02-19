using LandingDecider.Model;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace LandingDecider.Helper
{
    internal class JsonDataHelper
    {
        private string rootPath { get; set; }

        public JsonDataHelper()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\LandingDeciderData.json";

            rootPath = filePath;
        }

        public void WritePlatform(LandingPlatformModel obj)
        {
            using (StreamWriter writer = new StreamWriter(rootPath))
            {
                writer.WriteLine(JsonConvert.SerializeObject(obj));
            }
        }

        public LandingPlatformModel ReadPlatform()
        {
            LandingPlatformModel result;
            using (StreamReader reader = new StreamReader(rootPath))
            {
                result = JsonConvert.DeserializeObject<LandingPlatformModel>(reader.ReadToEnd());
                reader.Close();
            }
            return result;
        }

        public void EmptyPlatform()
        {
            using (StreamWriter writer = new StreamWriter(rootPath))
            {
                writer.WriteLine(JsonConvert.SerializeObject(new object()));
            }
        }
    }
}
