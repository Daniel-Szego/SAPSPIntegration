using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Wrappers
{
    public class EmployeeBasic
    {
        /// <summary>
        /// PERNR - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _PersonalNumber;

        /// <summary>
        /// ENAM - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _Name;

        /// <summary>
        /// ORGID - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _OrganisationID;

        /// <summary>
        /// ORGTEXT - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _OrganisationName;

        /// <summary>
        /// JobID - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _JobID;

        /// <summary>
        /// JobText - BAPI_EMPLOYEE_GETLIST
        /// </summary>
        private string _JobName;

        public string PersonalNumber 
        {
            get { return _PersonalNumber;}
            set { _PersonalNumber = value;}
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string OrganisationID
        {
            get { return _OrganisationID; }
            set { _OrganisationID = value; }
        }

        public string OrganisationName
        {
            get { return _OrganisationName; }
            set { _OrganisationName = value; }
        }

        public string JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }


    }
}
