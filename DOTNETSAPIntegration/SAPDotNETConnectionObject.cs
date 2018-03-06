using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data
{
    public class SAPDotNETConnectionObject : IDestinationConfiguration
    {
            bool IDestinationConfiguration.ChangeEventsSupported()
            {
                return true;
            }

            public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

            RfcConfigParameters IDestinationConfiguration.GetParameters(string destinationName)
            {
                if (Constants.DestinationNum.Equals(destinationName))
                {
                    RfcConfigParameters parms = new RfcConfigParameters();
                    parms.Add(RfcConfigParameters.AppServerHost, TestConfigSAPDotNet.ASHOST);
                    parms.Add(RfcConfigParameters.SystemNumber, TestConfigSAPDotNet.SYSNR);
                    parms.Add(RfcConfigParameters.User, TestConfigSAPDotNet.User);
                    parms.Add(RfcConfigParameters.Password, TestConfigSAPDotNet.Password);
                    parms.Add(RfcConfigParameters.Client, TestConfigSAPDotNet.Client);
                    parms.Add(RfcConfigParameters.Language, TestConfigSAPDotNet.LANG);
                    parms.Add(RfcConfigParameters.PoolSize, TestConfigSAPDotNet.PoolSize);
                    parms.Add(RfcConfigParameters.MaxPoolSize, TestConfigSAPDotNet.MaxPoolSize);
                    parms.Add(RfcConfigParameters.IdleTimeout, TestConfigSAPDotNet.IdleTimeout);

                    return parms;
                }
                return null;
            }

    }
}
