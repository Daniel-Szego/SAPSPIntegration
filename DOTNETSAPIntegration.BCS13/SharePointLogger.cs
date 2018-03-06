using DOTNETSAPIntegration.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.BCS13
{
    class SharePointLogger : ILogger
    {
         public override bool exceptionDelegeted
         {
              get { return true; }
         }

         public override void LogMessage(string message)
         {
             //Console.WriteLine(message);
         }

         public override void LogError(string errorMessage, Data.DOTNETSAPErrorSeverity severity)
         {
             //Console.WriteLine(errorMessage);
         }
    }
}
