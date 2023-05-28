using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ENT.Framework
{
    public static class RestHelper
    {
        public static StringContent GerarJson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static T DeserializeFromJson<T>(string jsonText)
        {
            var json = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var regex = new Regex(@",?""[_\w]+"":null");
            string nullless = regex.Replace(jsonText, string.Empty);

            var sr = new StringReader(nullless);
            var reader = new JsonTextReader(sr);
            var result = json.Deserialize(reader, typeof(T));
            reader.Close();

            return (T)result;
        }

        public static AuthenticationHeaderValue AutenticadorBasicAut(string pUsuario, string pSenha) =>
            new("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{pUsuario}:{pSenha}")));
    }
}
