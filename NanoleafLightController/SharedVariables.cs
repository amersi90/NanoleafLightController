using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafLightController
{
    class FileInfo
    {
        private readonly string _fileName = "connection_info.json";
        private readonly string _folderName = "Nanoleaf light controller";
        private string _path;

        public FileInfo()
        {
            _path = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDoc‌​uments), _folderName, _fileName);
        }

        public string GetFilePath()
        {
            return _path;
        }
        public string GetFolderName()
        {
            return _folderName;
        }
        public string GetFileName()
        {
            return _fileName;
        }
    }
}
