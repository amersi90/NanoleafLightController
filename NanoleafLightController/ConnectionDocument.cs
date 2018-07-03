using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NanoleafLightController
{
    class ConnectionDocument
    {
        private string _path;
        private string _fileContent;
        public string exceptionThrown;

        public ConnectionDocument(NanoleafConnectionInfo information)
        {
            
            _fileContent = JsonConvert.SerializeObject(information);
            _path = new FileInfo().GetFilePath();
            
        }

        public void CreateFile()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDoc‌​uments), new FileInfo().GetFolderName()));
            }
            try
            {
                using (FileStream fs = File.Create(_path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(_fileContent);
                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                exceptionThrown = ex.ToString();
            }
        }

    }
    

}
