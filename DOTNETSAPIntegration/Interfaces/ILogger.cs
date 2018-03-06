using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Interfaces
{
    /// <summary>
    /// General Interface for Logger
    /// </summary>
    public abstract class ILogger
    {

        public abstract bool exceptionDelegeted { get; }

        public abstract void LogMessage(string message);

        public abstract void LogError(string errorMessage, DOTNETSAPErrorSeverity severity);

        public void LogError(Exception ex, DOTNETSAPErrorSeverity severity)
        { 
           string errorMessage = ex.Message + " - " + ex.StackTrace != null ? string.Empty : ex.StackTrace.ToString();
           if (ex.InnerException != null)
           {
               errorMessage += " " + ex.InnerException.Message + " - " + ex.InnerException.StackTrace != null ? string.Empty : ex.InnerException.StackTrace.ToString();
           }

           this.LogError(errorMessage, severity);
        }

        public void ThrowException(Exception ex, DOTNETSAPErrorSeverity severity)
        { 
            this.LogError(ex, severity);
            if (exceptionDelegeted)
            {
                throw ex;
            }
        }

        public void ThrowException(string message, DOTNETSAPErrorSeverity severity)
        {
            this.LogError(message, severity);
            if (exceptionDelegeted)
            {
                throw new Exception(message);
            }
        }

    }
}
