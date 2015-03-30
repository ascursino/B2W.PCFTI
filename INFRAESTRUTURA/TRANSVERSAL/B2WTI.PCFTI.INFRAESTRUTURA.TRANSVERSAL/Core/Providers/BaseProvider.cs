
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Linq;
    using System.Text;

    public class BaseProvider
    {
        public static T ServiceInvoke<T>(string Method, NameValueCollection DataValue, string Url)
        {
            try
            {
                MemoryStream stream = RESTServiceInvoke(Method, DataValue, Url);
                T ret = (T)DeserializeFromStream<T>(stream);
                return ret;
            }
            catch
            {
                throw;
            }
        }

        public static MemoryStream RESTServiceInvoke(string Method, NameValueCollection DataValue, string Url)
        {
            MemoryStream ret = null;
            try
            {
                WebClient client = new WebClient();
                byte[] retRest = client.UploadValues(Url, Method, DataValue);
                ret = new MemoryStream(retRest);
            }
            catch
            {
            }
            return ret;
        }

        public static MemoryStream SerializeToStream(object objectType)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectType);
            return stream;
        }

        public static T DeserializeFromStream<T>(MemoryStream stream)
        {
            T obj = (T)JsonConvert.DeserializeObject((new StreamReader(stream)).ReadToEnd(), typeof(T));
            return obj;
        }

        public static Dictionary<string, string> DeserializeStreamValues(Stream stream)
        {
            const char Const_E = '&';
            const char Const_Igual = '=';
            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();
            var keyValuePairs = data.Split(Const_E)
                .Select(x => x.Split(Const_Igual))
                .Where(x => x.Length == 2)
                .ToDictionary(x => x.First(), x => x.Last());
            Dictionary<string, string> Lista = (Dictionary<string, string>)keyValuePairs;
            return Lista;
        }

        public static string MakeRequest(string url, string Method, string EncodingName, int TimeOut = 20000)
        {
            string ret = string.Empty;
            try
            {
                WebRequest w = WebRequest.Create(url);
                w.Method = Method;
                w.Timeout = TimeOut;
                WebResponse r = w.GetResponse();
                Encoding enc = Encoding.GetEncoding(EncodingName);
                StreamReader reader = new StreamReader(r.GetResponseStream(), enc);
                ret = reader.ReadToEnd();
            }
            catch
            {
            }
            return ret;
        }
    }
}
