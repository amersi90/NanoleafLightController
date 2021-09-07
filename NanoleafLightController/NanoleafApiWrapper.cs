using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NanoleafLightController.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
            var nanoLeafModel = new NanoLeafPropertiesModel{On = new NanoLeafValueBooleanModel(value)};
            SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
        }

        //Set hue value
        public void SetHue(int hValue)
        {
            if (hValue >= 0 && hValue <= 360)
            {
                var nanoLeafModel = new NanoLeafPropertiesModel{Hue = new NanoLeafValueIntegerModel(hValue)};
                SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
            }

        }
        //Set saturation value
        public void SetSaturation(int saturationValue)
        {
            if (saturationValue >= 0 && saturationValue <= 100)
            {
                var nanoLeafModel = new NanoLeafPropertiesModel { Saturation = new NanoLeafValueIntegerModel(saturationValue) };
                SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
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
                var nanoLeafModel = new NanoLeafPropertiesModel { Brightness = new NanoLeafValueIntegerModel(brightnessValue) };
                SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
            }
            
        }

        public void SetHueAndSaturation(int hue, int saturation)
        {
            
                if ((saturation >= 0 && saturation <= 100) && (hue >= 0 && hue <= 360))
                {
                    var nanoLeafModel = new NanoLeafPropertiesModel
                    {
                        Hue = new NanoLeafValueIntegerModel(hue),
                        Saturation = new NanoLeafValueIntegerModel(saturation)
                    };
                    SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
                }
            
            
        }

        public void SetColor(Color color)
        {
            var nanoLeafModel = new NanoLeafPropertiesModel
            {
                //Should maybe crate a constructor for color?
                Saturation = new NanoLeafValueIntegerModel((int)Math.Round(color.GetSaturation()*100)),
                Hue = new NanoLeafValueIntegerModel((int)Math.Round(color.GetHue()))

            };
            SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
        }

        /// <summary>
        /// Select effect to show on aurora
        /// </summary>
        /// <param name="effect"></param>
        public void SetEffect(string effectName)
        {
            var nanoLeafModel = new NanoLeafPropertiesModel { Select = new NanoLeafSelectStringModel(effectName) };
            SendRequest(_connectionString + "/effects", "PUT", nanoLeafModel.ToString());
        }
        /// <summary>
        /// Sets colortemperature based on kelvin
        /// </summary>
        /// <param name="colorTemperature">Accepted values: 1200-6500</param>
        public void SetColorTemperature(int colorTemperature)
        {
            if (colorTemperature >= 1200 && colorTemperature <= 6500)
            {
                var nanoLeafModel = new NanoLeafPropertiesModel { ColorTemperature = new NanoLeafValueIntegerModel(colorTemperature) };
                SendRequest(_connectionString + "/state", "PUT", nanoLeafModel.ToString());
            }
        }

        public string GetToken()
        {
            return SendRequest(_connectionString + "new", "POST", "");
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
                return client.DownloadString(conString);
            }
        }
        //Sending post,put,delete
        private string SendRequest(string conString, string httpMethod, string data)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    return client.UploadString(conString, httpMethod, data);
                }
            }
            catch(WebException e)
            {
                return e.Message;
            }
            
            
            
        }
        public bool ConvertToBool(string s)
        {
            var jData = (JObject)JsonConvert.DeserializeObject(s);
            return jData["value"].Value<bool>();
        }
        public int ConvertToInteger(string s)
        {
            var jData = (JObject)JsonConvert.DeserializeObject(s);
            return jData["value"].Value<int>();
        }
        
    }
}
