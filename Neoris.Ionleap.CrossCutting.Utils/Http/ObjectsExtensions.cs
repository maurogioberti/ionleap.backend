using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace Neoris.Ionleap.CrossCutting.Utils.Http
{

    public static class FormExtensions
    {

        public static FormUrlEncodedContent ToFormData(this object obj)
        {
            var formData = obj.ToKeyValue();

            return new FormUrlEncodedContent(formData);
        }

        public static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            //if (metaToken == null)
            //{
            //    return null;
            //}

            //// Added by me: avoid cyclic references
            //var serializer = new JsonSerializer { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //var token = metaToken as JToken;
            //if (token == null)
            //{
            //    // Modified by me: use serializer defined above
            //    return ToKeyValue(JObject.FromObject(metaToken, serializer));
            //}

            //if (token.HasValues)
            //{
            //    var contentData = new Dictionary<string, string>();
            //    foreach (var child in token.Children().ToList())
            //    {
            //        var childContent = child.ToKeyValue();
            //        if (childContent != null)
            //        {
            //            contentData = contentData.Concat(childContent)
            //                                     .ToDictionary(k => k.Key, v => v.Value);
            //        }
            //    }

            //    return contentData;
            //}

            //var jValue = token as JValue;
            //if (jValue?.Value == null)
            //{
            //    return null;
            //}

            //var value = jValue?.Type == JTokenType.Date ?
            //                jValue?.ToString("o", CultureInfo.InvariantCulture) :
            //                jValue?.ToString(CultureInfo.InvariantCulture);

            //return new Dictionary<string, string> { { token.Path, value } };
            // Se uso la referencia de Newtonsoft para transferir de RawContent a un objeto
            // Se puede hacer lo mismo sin utilizar la librería, y el Job por ahora quedó comentado

            return null;
        }

        public static string ToRawContent(this object source)
        {
            string raw = "";
            int index = 0;
            PropertyInfo[] properties = source.GetType().GetProperties();
            foreach (var property in properties)
            {
                index++;
                raw += $"{property.Name}={property.GetValue(source, null)}";

                if (index != properties.Count())
                {
                    raw += "&";
                }
            }

            return raw;
        }
    }
}
