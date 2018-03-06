using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Wrappers
{
    public class EmployeeDetail
    {
        public EmployeeBasic employeeBasic { get; set;}

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMeOFFORMOFADD
        private string _NamePrefix;

        // BAPI_PERSDATA_GETDETAILEDLIST - FIRSTNAME
        private string _FirstName;

        // BAPI_PERSDATA_GETDETAILEDLIST - LASTNAME
        private string _LastName;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFLANGUAGE
        private string _Language;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFNATIONALI
        private string _Nationality;

        // BAPI_PERSDATA_GETDETAILEDLIST - DATEOFBIRTH
        private string _DateOfBith;

        // BAPI_PERSDATA_GETDETAILEDLIST - BIRTHPLACE
        private string _PlaceOfBith;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFGENDER
        private string _Gender;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFCOUNTRYOF
        private string _Country;


        public string NamePrefix
        {
            get { return _NamePrefix; }
            set { _NamePrefix = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }

        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }

        public string DateOfBith
        {
            get { return _DateOfBith; }
            set { _DateOfBith = value; }
        }

        public string PlaceOfBith
        {
            get { return _PlaceOfBith; }
            set { _PlaceOfBith = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

    }
}
