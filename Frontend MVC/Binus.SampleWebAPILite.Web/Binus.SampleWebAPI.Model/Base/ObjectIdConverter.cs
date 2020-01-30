using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.Base
{
  public  class ObjectIdConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //JToken Token = JToken.Load(reader);
            //return new ObjectId(Token.Value<string>("$oid").ToString());
            JToken Token = JToken.Load(reader);
            if (Token is JObject)
            {
                return new ObjectId(Token.Value<string>("$oid").ToString());
            }
            else
            {
                JArray JArray = JArray.Parse(Token.ToString());
                List<ObjectId> Data = new List<ObjectId>();

                try
                {
                    foreach (JObject Item in JArray)
                    {
                        if (Item["_id"] != null)
                        {
                            Data.Add(new ObjectId(Item["_id"].Value<string>("$oid").ToString()));
                        }

                        else
                        {

                            Data.Add(new ObjectId(Item.Value<string>("$oid").ToString()));
                        }
                    }
                }
                catch (Exception EX)
                {

                }

                //string name = item.GetValue("name");
                //string url = item.GetValue("url");
                //// ...

                return Data;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
            //return true;
        }


    }
}
