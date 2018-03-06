using DOTNETSAPIntegration.Data;
using DOTNETSAPIntegration.Data.Repository;
using DOTNETSAPIntegration.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNETSAPIntegration.ConsoleOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start - Test Theobald Connector");
            ConsoleLogger logger = new ConsoleLogger();
            TestConfigTh config = new TestConfigTh();
            TestLicense license = new TestLicense();

            using (EmployeeRepositoryTh rep = new EmployeeRepositoryTh(config, logger, license))
            {
                List<EmployeeBasic> empList = rep.getEmployeeBasicList();
                foreach (var emp in empList)
                {
                    Console.WriteLine(emp.PersonalNumber);
                }

                EmployeeDetail det = rep.getEmployeeDetailedInfo("00001000");
                Console.WriteLine(det.LastName);
            }
            Console.WriteLine("End Test Theobald Connector");
            Console.ReadLine();


            Console.WriteLine("Start - Test SAP.NET Connector");
            ConsoleLogger loggers = new ConsoleLogger();
            TestConfigTh configs = new TestConfigTh();
            TestLicense licenses = new TestLicense();

            using (EmployeeRepositorySAPDotNet rep = new EmployeeRepositorySAPDotNet(configs, loggers, licenses))
            {
                List<EmployeeBasic> empList = rep.getEmployeeBasicList();
                foreach (var emp in empList)
                {
                    Console.WriteLine(emp.PersonalNumber);
                }

                EmployeeDetail det = rep.getEmployeeDetailedInfo("00001000");
                Console.WriteLine(det.LastName);
            }
            Console.WriteLine("End Test SAP.NET Connector");
            Console.ReadLine();

        }
    }
}
