using DOTNETSAPIntegration.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTNETSAPIntegration.BCS13.EmployeeData
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class EntityEmployeeData
    {

        public EntityEmployeeData()
        {
        }

        public EntityEmployeeData (EmployeeBasic empBasic) 
        {
            PersonalNumber = empBasic.PersonalNumber;
            Name = empBasic.Name;
            OrganisationID = empBasic.OrganisationID;
            OrganisationName = empBasic.OrganisationName;
            JobID = empBasic.JobID;
            JobName = empBasic.JobName;            
        }

        public EntityEmployeeData(EmployeeBasic empBasic, EmployeeDetail empDetail)
        {
            PersonalNumber = empBasic.PersonalNumber;
            Name = empBasic.Name;
            OrganisationID = empBasic.OrganisationID;
            OrganisationName = empBasic.OrganisationName;
            JobID = empBasic.JobID;
            JobName = empBasic.JobName;

            NamePrefix = empDetail.NamePrefix;
            FirstName = empDetail.FirstName;
            LastName = empDetail.LastName;
            Language = empDetail.Language;
            Nationality = empDetail.Nationality;
            DateOfBith = empDetail.DateOfBith;
            PlaceOfBith = empDetail.PlaceOfBith;
            Gender = empDetail.Gender;
            Country = empDetail.Country;
        }

        //TODO: Implement additional properties here. The property Message is just a sample how a property could look like.

        private string _PersonalNumber;
        private string _Name;
        private string _OrganisationID;
        private string _OrganisationName;
        private string _JobID;
        private string _JobName;
        private string _NamePrefix;
        private string _FirstName;
        private string _LastName;
        private string _Language;
        private string _Nationality;
        private string _DateOfBith;
        private string _PlaceOfBith;
        private string _Gender;
        private string _Country;
        
        public string PersonalNumber
        {
            get { return _PersonalNumber; }
            set { _PersonalNumber = value; }
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
