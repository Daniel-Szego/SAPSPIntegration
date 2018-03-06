using DOTNETSAPIntegration.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data
{
    /// <summary>
    /// Test config for Theobald Connector
    /// </summary>
    public class TestConfigTh : IConfig
    {
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
    }
}
