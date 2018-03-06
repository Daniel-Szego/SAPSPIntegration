using DOTNETSAPIntegration.Data;
using DOTNETSAPIntegration.Data.Repository;
using DOTNETSAPIntegration.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTNETSAPIntegration.BCS13.EmployeeData
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class EmployeeDataService
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public static EntityEmployeeData ReadItem(string PersonalNumber)
        {
            EmployeeBasic basicInfo = null;
            EmployeeDetail detailedInfo = null;
            EntityEmployeeData ret = new EntityEmployeeData();

            SharePointLogger logger = new SharePointLogger();
            TestConfigTh config = new TestConfigTh();
            TestLicense license = new TestLicense();


            using (EmployeeRepositorySAPDotNet rep = new EmployeeRepositorySAPDotNet(config, logger, license))
            {
                List<EmployeeBasic> empList = rep.getEmployeeBasicList();
                foreach (EmployeeBasic emp in empList)
                {
                    if (emp.PersonalNumber.ToLower().Trim().Equals(PersonalNumber.ToLower().Trim()))
                        basicInfo = emp;
                }
                if (basicInfo != null)
                {
                    detailedInfo = rep.getEmployeeDetailedInfo(PersonalNumber);
                }
            }

            if (basicInfo != null)
            {
                ret = new EntityEmployeeData(basicInfo, detailedInfo);
            }

            return ret;
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<EntityEmployeeData> ReadList()
        {
            List<EntityEmployeeData> returnList = new List<EntityEmployeeData>();

            SharePointLogger logger = new SharePointLogger();
            TestConfigTh config = new TestConfigTh();
            TestLicense license = new TestLicense();

            using (EmployeeRepositorySAPDotNet rep = new EmployeeRepositorySAPDotNet(config, logger, license))
            {
                List<EmployeeBasic> empList = rep.getEmployeeBasicList();
                foreach (EmployeeBasic emp in empList)
                {
                    returnList.Add(new EntityEmployeeData(emp));
                }
            }
            return returnList;
        }
    }
}
