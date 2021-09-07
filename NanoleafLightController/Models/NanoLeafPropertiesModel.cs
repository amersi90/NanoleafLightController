using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NanoleafLightController.Models
{
    public class NanoLeafPropertiesModel
    {
        public NanoLeafValueBooleanModel On { get; set; }
        public NanoLeafValueIntegerModel Brightness { get; set; }
        public NanoLeafValueIntegerModel Hue { get; set; }
        [JsonProperty("sat")]
        public NanoLeafValueIntegerModel Saturation { get; set; }
        public NanoLeafSelectStringModel Select { get; set; }
        [JsonProperty("ct")]
        public NanoLeafValueIntegerModel ColorTemperature { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }


    public class NanoLeafValueBooleanModel
    {
        public NanoLeafValueBooleanModel(bool value)
        {
            Value = value;
        }
        public bool Value { get; set; }
    }

    public class NanoLeafSelectStringModel
    {
        public NanoLeafSelectStringModel(string value)
        {
            Select = value;
        }
        public string Select { get; set; }

    }

    public class NanoLeafValueIntegerModel
    {
        public NanoLeafValueIntegerModel(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }

}
