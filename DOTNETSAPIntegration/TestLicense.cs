using DOTNETSAPIntegration.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data
{
    public class TestLicense : ILicense
    {
        bool ILicense.IsLicenseValid()
        {
            return true;
        }
    }
}
