using DOTNETSAPIntegration.Data.Interfaces;
using DOTNETSAPIntegration.Data.Wrappers;
using ERPConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Repository
{
    public class EmployeeRepositoryTh: IDisposable
    {
        private IConfig _configManager;

        private ILogger _loggingManager;

        private ILicense _licenseManager;

        public EmployeeRepositoryTh(IConfig configManager, ILogger loggingManager, ILicense licenseManager)
        {
            if (loggingManager == null)
            {
                throw new Exception("Logging Manager is not to be found");            
            }
            else if (configManager == null)
            {
                _loggingManager.ThrowException("Config Manager is not to be found", DOTNETSAPErrorSeverity.High);
            }
            else if (licenseManager == null)
            {
                _loggingManager.ThrowException("License Manager is not to be found", DOTNETSAPErrorSeverity.High);
            }
            else if (!licenseManager.IsLicenseValid())
            {
                _loggingManager.ThrowException("License is not valid !", DOTNETSAPErrorSeverity.High);
            }

            _configManager = configManager;
            _loggingManager = loggingManager;
            _licenseManager = licenseManager;
        }


        public List<EmployeeBasic> getEmployeeBasicList()
        { 
              return getEmployeeBasicList(string.Empty, string.Empty, string.Empty, string.Empty);
        }


        public List<EmployeeBasic> getEmployeeBasicList(string surname, string lastname, string job, string organisation)
        {
            string surnameSearch = surname.Equals(string.Empty) ? "*" : surname;
            string lastnameSearch = lastname.Equals(string.Empty) ? "*" : lastname;
            string jobSearch = job.Equals(string.Empty) ? "*" : job;
            string organisationSearch = organisation.Equals(string.Empty) ? "*" : organisation;

            List<EmployeeBasic> result = new List<EmployeeBasic>();
            var connection = new R3Connection(_configManager.getConnectionString());

            try
            {
                connection.Open();

                var function = connection.CreateFunction(Constants.BAPI_EMPLOYEE_GETLIST);
                function.Exports[Constants.SEARCH_DATE].ParamValue = DateTime.Now.ToShortDateString();
                function.Exports[Constants.JOB_SEARK].ParamValue = jobSearch;
                function.Exports[Constants.JOB_SEARK].ParamValue = jobSearch;
                function.Exports[Constants.ORG_SEARK].ParamValue = organisationSearch;
                function.Exports[Constants.SUR_NAME_SEARK].ParamValue = surnameSearch;
                function.Exports[Constants.LST_NAME_SEARK].ParamValue = lastnameSearch;

                function.Execute();

                    var table = function.Tables[Constants.EMPLOYEE_LIST];

                    if (table != null && table.Rows.Count > 0)
                    {
                        foreach (RFCStructure row in table.Rows)
                        {
                            var PERNR = (string)row[Constants.PERNR];
                            var ENAME = (string)row[Constants.ENAME];
                            var ORG_ID = (string)row[Constants.ORG_ID];
                            var ORG_TEXT = (string)row[Constants.ORG_TEXT];
                            var JOB_ID = (string)row[Constants.JOB_ID];
                            var JOB_TEXT = (string)row[Constants.JOB_TEXT];

                            EmployeeBasic empBasic = new EmployeeBasic()
                            {
                                Name = ENAME,
                                JobID = JOB_ID,
                                JobName = JOB_TEXT,
                                OrganisationID = ORG_TEXT,
                                OrganisationName = ORG_TEXT,
                                PersonalNumber = PERNR
                            };

                            result.Add(empBasic);
                        }
                   }
            }
            catch (Exception ex)
            {
                _loggingManager.ThrowException(ex, DOTNETSAPErrorSeverity.High);
            }
            finally
            {
                 if (connection != null && connection.Ping())
                     connection.Close();
            }

            return result;
        }


        public EmployeeDetail getEmployeeDetailedInfo(string personalNr)
        {

            EmployeeDetail result = null;
            if (!personalNr.Equals(string.Empty))
            {
                var connection = new R3Connection(_configManager.getConnectionString());

                try
                {
                    connection.Open();

                    var function = connection.CreateFunction(Constants.BAPI_PERSDATA_GETDETAILEDLIST);
                    function.Exports[Constants.EMPLOYEENUMBER].ParamValue = personalNr;

                    function.Execute();

                    var table = function.Tables[Constants.PERSONALDATA];

                    if (table != null || table.Rows.Count > 0)
                    {

                        foreach (RFCStructure row in table.Rows)
                        {
                            var NAMeOFFORMOFADD = (string)row[Constants.NAMeOFFORMOFADD];
                            var FIRSTNAME = (string)row[Constants.FIRSTNAME];
                            var LASTNAME = (string)row[Constants.LASTNAME];
                            var NAMEOFLANGUAGE = (string)row[Constants.NAMEOFLANGUAGE];
                            var NAMEOFNATIONALI = (string)row[Constants.NAMEOFNATIONALITY];
                            var DATEOFBIRTH = (string)row[Constants.DATEOFBIRTH];
                            var BIRTHPLACE = (string)row[Constants.BIRTHPLACE];
                            var NAMEOFGENDER = (string)row[Constants.NAMEOFGENDER];
                            var NAMEOFCOUNTRYOF = (string)row[Constants.NAMEOFCOUNTRYOF];

                            result = new EmployeeDetail()
                            {
                                Country = NAMEOFCOUNTRYOF,
                                DateOfBith = DATEOFBIRTH,
                                FirstName = FIRSTNAME,
                                Gender = NAMEOFGENDER,
                                Language = NAMEOFLANGUAGE,
                                LastName = LASTNAME,
                                NamePrefix = NAMeOFFORMOFADD,
                                Nationality = NAMEOFNATIONALI,
                                PlaceOfBith = BIRTHPLACE
                            };

                        }
                    }
                }
                catch (Exception ex)
                {
                    _loggingManager.ThrowException(ex, DOTNETSAPErrorSeverity.High);
                }
                finally
                {
                    if (connection != null && connection.Ping())
                        connection.Close();
                }
            }
            return result;
        }




        public void Dispose()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
