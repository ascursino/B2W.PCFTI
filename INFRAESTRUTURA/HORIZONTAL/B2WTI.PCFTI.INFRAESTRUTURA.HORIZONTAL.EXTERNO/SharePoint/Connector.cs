
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.EXTERNO
{
    using System;
    using System.Net;
    using PCFTIService.SP.Data;

    sealed class Connector
    {

        private static readonly Connector _instance = new Connector();
        
        public static Connector Load()
        {
            return _instance; 
        }

        public ListData Connect()
        {
            ListData ld = null;
            try
            {
                ld = new ListData(new Uri("http://portalti.b2w/orcamento/pcfti/_api/"))
                {
                    Credentials = new NetworkCredential("portalpmo", "b2w@123456", "LAB2W")
                };
            }
            catch
            {
                throw;
            }
            return ld;
        }

    }
}
