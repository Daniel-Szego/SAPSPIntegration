using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Interfaces
{
    /// <summary>
    /// Interface for general configuration settings
    /// </summary>
    public interface IConfig
    {
        string getASHOST();

        string getSYSNR();

        string getUser();

        string getPassword();

        string getLANG();

        string getClient();

        string getConnectionString();

    }
}
