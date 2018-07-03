using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data;

namespace NanoleafLightController
{
    class JsonDeserializer 
    {
        public static NanoleafConnectionInfo ConvertFromFile(string path)
        {
            NanoleafConnectionInfo nCI = new NanoleafConnectionInfo();
            if (File.Exists(path))
            {
                string fileContent = File.ReadAllText(path);
                nCI = JsonConvert.DeserializeObject<NanoleafConnectionInfo>(fileContent);
            }
            return nCI;
        }
        
        public static List<string> ListOfEffects(string text)
        {
            Effects items = JsonConvert.DeserializeObject<Effects>(text);
            return items.effectsList;
        }

    }
    public class Effects
    {
        public List<string> effectsList { get; set; }
    }

    
}
