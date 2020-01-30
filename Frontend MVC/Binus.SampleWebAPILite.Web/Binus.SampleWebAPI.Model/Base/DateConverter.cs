using Binus.WebAPI.Utility.DateTime;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.Base
{
  public  class DateConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
          
            DateTime Formated = JakartaTime.Convert(value);
           
            serializer.Serialize(writer, Formated.ToString());

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            try
            {
                if (token.HasValues)
                {

                    return epoch.AddMilliseconds(Convert.ToDouble(token.Value<string>("$date").ToString()));
                }
                else
                {
                    return epoch;
                }
            }
            catch(Exception Ex)
            {
                return epoch;
            }
            
            
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
            //return true;
        }


    }
}
