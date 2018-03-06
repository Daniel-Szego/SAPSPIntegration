using DOTNETSAPIntegration.Data.Interfaces;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data
{
    public class TestConfigSAPDotNet: IConfig 
    {
        public static string ASHOST = "169.254.220.238";
        public static string SYSNR = "00";
        public static string User = "root";
        public static string Password = "maximal";
        public static string LANG = "EN";
        public static string Client = "800";
        public static string PoolSize = "50";
        public static string MaxPoolSize = "100";
        public static string IdleTimeout = "6000";

        string IConfig.getASHOST()
        {
            return "169.254.220.238";
        }

        string IConfig.getSYSNR()
        {
            return "K47";
        }

        string IConfig.getUser()
        {
            return "root";
        }

        string IConfig.getPassword()
        {
            return "maximal";
        }

        string IConfig.getLANG()
        {
            return "EN";
        }

        string IConfig.getClient()
        {
            return "800";
        }

        string IConfig.getConnectionString()
        {
            return "ASHOST=169.254.220.238 SYSNR=K47 USER=root PASSWD=maximal LANG=EN CLIENT=800";
        }

        public static RfcDestination rfcDest = null;

        public static object getConnectionObject()
        {
            if (rfcDest == null)
            {
                SAPDotNETConnectionObject sapCfg = new SAPDotNETConnectionObject();
                RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
                rfcDest = RfcDestinationManager.GetDestination(Constants.DestinationNum);
            }
            return rfcDest;
        }
    }
}
