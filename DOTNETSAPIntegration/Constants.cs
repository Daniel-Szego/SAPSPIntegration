using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data
{
    public static class Constants
    {
        #region BAPI_EMPLOYEE_GETLIST
        // BAPI
        public static string BAPI_EMPLOYEE_GETLIST = "BAPI_EMPLOYEE_GETLIST";
        // input params
        public static string ORG_SEARK = "ORG_SEARK";
        public static string JOB_SEARK = "JOB_SEARK";
        public static string SUR_NAME_SEARK = "SUR_NAME_SEARK";
        public static string LST_NAME_SEARK = "LST_NAME_SEARK";
        public static string SEARCH_DATE = "SEARCH_DATE";
        // output params
        public static string EMPLOYEE_LIST = "EMPLOYEE_LIST";
        public static string PERNR = "PERNR";
        public static string ENAME = "ENAME";
        public static string ORG_ID = "ORG_ID";
        public static string ORG_TEXT = "ORG_TEXT";
        public static string JOB_ID = "JOB_ID";
        public static string JOB_TEXT = "JOB_TEXT";

        #endregion

        #region BAPI_PERSDATA_GETDETAILEDLIST
        // BAPI
        public static string BAPI_PERSDATA_GETDETAILEDLIST = "BAPI_PERSDATA_GETDETAILEDLIST";
        // input params
        public static string EMPLOYEENUMBER = "EMPLOYEENUMBER";
        // output params
        public static string PERSONALDATA = "PERSONALDATA";
        public static string FIRSTNAME = "FIRSTNAME";
        public static string LASTNAME = "LASTNAME";
        public static string NAMEOFNATIONALITY = "NAMEOFNATIONALITY";
        public static string NAMEOFLANGUAGE = "NAMEOFLANGUAGE";
        public static string NAMeOFFORMOFADD = "FORMOFADDRESS";
        public static string DATEOFBIRTH = "DATEOFBIRTH";
        public static string BIRTHPLACE = "BIRTHPLACE";
        public static string NAMEOFGENDER = "NAMEOFGENDER";
        public static string NAMEOFCOUNTRYOF = "NAMEOFCOUNTRYOFBIRTH";

        #endregion

        public static string DestinationNum = "K47";
    }

    public enum DOTNETSAPErrorSeverity : int
    {
        Low = 1,
        Medium = 2,
        High = 3
    };
}
