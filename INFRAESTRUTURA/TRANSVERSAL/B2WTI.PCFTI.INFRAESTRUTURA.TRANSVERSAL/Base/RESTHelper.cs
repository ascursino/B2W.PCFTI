
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class RESTHelper
    {
        public static async Task<string> GetString(string URI, int SecondsTimeout)
        {
            string ret = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(SecondsTimeout);
                    var response = await client.GetAsync(URI);
                    var json = await response.Content.ReadAsStringAsync();
                    ret = json.ToString();
                    client.Dispose();
                }
            }
            catch (Exception Ex)
            {
                ret = Ex.Message;
            }
            return ret;
        }
    }
}
