using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafLightController
{
    class NanoleafApiWrapper
    {
        private string _token;
        private string _ipAdress;
        private string _portNumber;
        private string _connectionString;

        public NanoleafApiWrapper(string ipAdress, string port)
        {
            _ipAdress = ipAdress;
            _portNumber = port;
            _connectionString = "http://" + ipAdress + ":" + port + "/api/v1/";

        }

        public NanoleafApiWrapper(string ipAdress, string port, string token)
        {
            _ipAdress = ipAdress;
            _portNumber = port;
            _token = token;
            _connectionString = "http://" + ipAdress + ":" + port + "/api/v1/"+_token;
        }

        public void SetToken(string token)
        {
            _token = token;
            _connectionString = _connectionString + _token;

        }
        //Toogles aurora on/off
        public void SetState(bool value)
        {
            string jsonBody = "{\"on\":{\"value\":" + value.ToString().ToLower() + "" + "}}";

            SendRequest(_connectionString + "/state", "PUT", jsonBody);
        }

        //Set hue value
        public void SetHue(int hValue)
        {
            if (hValue >= 0 && hValue <= 360)
            {
                string jsonBody = "{\"hue\":{\"value\":" + hValue + "}}";
                SendRequest(_connectionString + "/state", "PUT", jsonBody);
            }

        }
        //Set saturation value
        public void SetSaturation(int saturationValue)
        {
            if (saturationValue >= 0 && saturationValue <= 100)
            {
                string jsonBody = "{\"sat\":{\"value\":" + saturationValue + "}}";
                SendRequest(_connectionString + "/state", "PUT", jsonBody);
            }
        }
        /// <summary>
        /// Set brightness value
        /// </summary>
        /// <param name="brightnessValue">Accepted value 2-100</param>
        public void SetBrightness(int brightnessValue)
        {
            if (brightnessValue >1 && brightnessValue <= 100)
            {
                string jsonBody = "{\"brightness\":{\"value\":" + brightnessValue + "}}";
                SendRequest(_connectionString + "/state", "PUT", jsonBody);
            }
            
        }

        public void SetHueAndSaturation(int hue, int saturation)
        {
            
                if ((saturation >= 0 && saturation <= 100) && (hue >= 0 && hue <= 360))
                {
                    string jsonData = "{\"hue\":{\"value\":" + hue + "},\"sat\" :{\"value\":" + saturation + "}}";
                    SendRequest(_connectionString + "/state", "PUT", jsonData);
                }
            
            
        }

        public void SetColor(Color color)
        {
            string jsonData = "{\"hue\":{\"value\":" + (int)Math.Round(color.GetHue()) + "},\"sat\" :{\"value\":" + (int)Math.Round(color.GetSaturation() * 100) + "}}";
            SendRequest(_connectionString + "/state", "PUT", jsonData);
        }

        public void SetColorForEachPanel(string data)
        {
            string msg =
                "{\"write\" : {\r\n\"command\" : \"display\",\r\n\"animType\" : \"static\",\r\n\"animData\" : \""+data +
                "\",\r\n\"loop\" : false\r\n}}";

            SendRequest(_connectionString + "/effects", "PUT", msg);
            
        }
        /// <summary>
        /// Select effect to show on aurora
        /// </summary>
        /// <param name="effect"></param>
        public void SetEffect(string effectName)
        {
            
            string jsonString = "{\"select\":\"" + effectName + "\"}";
            SendRequest(_connectionString + "/effects", "PUT", jsonString);

        }
        /// <summary>
        /// Sets colortemperature based on kelvin
        /// </summary>
        /// <param name="colorTemperature">Accepted values: 1200-6500</param>
        public void SetColorTemperature(int colorTemperature)
        {
            if (colorTemperature >= 1200 && colorTemperature <= 6500)
            {
                string jsonData = "{\"ct\":{\"value\":" + colorTemperature + "}}";
                SendRequest(_connectionString + "/state", "PUT", jsonData);
            }
        }


        

        public string GetToken()
        {

            return Encoding.ASCII.GetString(SendRequest(_connectionString + "new", "POST", ""));

        }
        /// <summary>
        /// Returns information about each panel
        /// </summary>
        /// <returns>String with json data</returns>
        public string GetPanelLayout()
        {
            string url = _connectionString + "/panelLayout/layout";
            return GetRequest(url);
        }
        /// <summary>
        /// Returns information about brightness
        /// </summary>
        /// <returns>String with json data</returns>
        public string GetBrightnessValue()
        {
            string url = _connectionString + "/state/brightness";
            return GetRequest(url);
        }

        public string GetEffets()
        {
            string url = _connectionString + "/effects";
            return GetRequest(url);
        }

        public bool GetLightStatus()
        {
            string url = _connectionString + "/state/on";
            return ConvertToBool(GetRequest(url));
        }

        public int GetLightBrightness()
        {
            string url = _connectionString + "/state/brightness";
            return ConvertToInteger(GetRequest(url));
        }
        /// <summary>
        /// Gets all information about aurora
        /// </summary>
        /// <returns>Json data</returns>
        public string GetAuroraInfo()
        {
            string url = _connectionString + "/";
            return GetRequest(url);
        }

        //Send get request to aurora
        private string GetRequest(string conString)
        {
            using (var client = new System.Net.WebClient())
            {
                byte[] recievedData = client.DownloadData(conString);
                string convertedData = Encoding.ASCII.GetString(recievedData);
                return convertedData;
            }
        }
        //Sending post,put,delete
        private byte[] SendRequest(string conString, string httpMethod, string data)
        {
            byte[] response;
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    response = client.UploadData(conString, httpMethod, Encoding.ASCII.GetBytes(data));
                    return response;
                }
            }
            catch(WebException e)
            {

                return Encoding.ASCII.GetBytes(e.ToString()); 
            }
            
            
            
        }
        public bool ConvertToBool(string s)
        {
            Dictionary<string, string> d = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            s = d["value"];
            if (s == "true")
                return true;
            else
                return false;
        }
        public int ConvertToInteger(string s)
        {
            Dictionary<string, string> d = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            s = d["value"];
            return Convert.ToInt32(s);
        }
        
    }
}
