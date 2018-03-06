using DOTNETSAPIntegration.Data.Interfaces;
using DOTNETSAPIntegration.Data.Wrappers;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.Data.Repository
{
    public class EmployeeRepositorySAPDotNet : IDisposable
    {
        private IConfig _configManager;

        private ILogger _loggingManager;

        private ILicense _licenseManager;

        public EmployeeRepositorySAPDotNet(IConfig configManager, ILogger loggingManager, ILicense licenseManager)
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
            RfcDestination destination = (RfcDestination) (TestConfigSAPDotNet.getConnectionObject());

            try
            {

                RfcRepository repo = destination.Repository;
                IRfcFunction employeeList = repo.CreateFunction(Constants.BAPI_EMPLOYEE_GETLIST);
//                employeeList.SetValue(Constants.SEARCH_DATE, DateTime.Now.ToShortDateString());

                employeeList.SetValue(Constants.JOB_SEARK, jobSearch);
                employeeList.SetValue(Constants.ORG_SEARK, organisationSearch);
                employeeList.SetValue(Constants.SUR_NAME_SEARK, surnameSearch);
                employeeList.SetValue(Constants.LST_NAME_SEARK, lastnameSearch);

                employeeList.Invoke(destination);
                IRfcTable employees = employeeList.GetTable(Constants.EMPLOYEE_LIST);

                for (int cuIndex = 0; cuIndex < employees.RowCount; cuIndex++)
                {
                    employees.CurrentIndex = cuIndex;

                    var PERNR = employees.GetString(Constants.PERNR);
                    var ENAME = employees.GetString(Constants.ENAME);
                    var ORG_ID = employees.GetString(Constants.ORG_ID);
                    var ORG_TEXT = employees.GetString(Constants.ORG_TEXT);
                    var JOB_ID = employees.GetString(Constants.JOB_ID);
                    var JOB_TEXT = employees.GetString(Constants.JOB_TEXT);

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
            catch (Exception ex)
            {
                _loggingManager.ThrowException(ex, DOTNETSAPErrorSeverity.High);
            }
            finally
            {
            }

            return result;
        }


        public EmployeeDetail getEmployeeDetailedInfo(string personalNr)
        {

            EmployeeDetail result = null;
            RfcDestination destination = (RfcDestination)(TestConfigSAPDotNet.getConnectionObject());

            if (!personalNr.Equals(string.Empty))
            {

                try
                {
                    RfcRepository repo = destination.Repository;
                    IRfcFunction employeeList = repo.CreateFunction(Constants.BAPI_PERSDATA_GETDETAILEDLIST);
                    employeeList.SetValue(Constants.EMPLOYEENUMBER, personalNr);

                    employeeList.Invoke(destination);
                    IRfcTable employees = employeeList.GetTable(Constants.PERSONALDATA);

                    for (int cuIndex = 0; cuIndex < employees.RowCount; cuIndex++)
                    {
                        employees.CurrentIndex = cuIndex;

                        var NAMeOFFORMOFADD = employees.GetString(Constants.NAMeOFFORMOFADD);
                        var FIRSTNAME = employees.GetString(Constants.FIRSTNAME);
                        var LASTNAME = employees.GetString(Constants.LASTNAME);
                        var NAMEOFLANGUAGE = employees.GetString(Constants.NAMEOFLANGUAGE);
                        var NAMEOFNATIONALI = employees.GetString(Constants.NAMEOFNATIONALITY);
                        var DATEOFBIRTH = employees.GetString(Constants.DATEOFBIRTH);
                        var BIRTHPLACE = employees.GetString(Constants.BIRTHPLACE);
                        var NAMEOFGENDER = employees.GetString(Constants.NAMEOFGENDER);
                        var NAMEOFCOUNTRYOF = employees.GetString(Constants.NAMEOFCOUNTRYOF);

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
                catch (Exception ex)
                {
                    _loggingManager.ThrowException(ex, DOTNETSAPErrorSeverity.High);
                }
                finally
                {
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
