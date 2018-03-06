using System.Runtime.Serialization;
using System;

namespace Acme.Service.DataContracts
{
    [DataContract]
    public class Employee
    {
        int _empID = 0;
        int _persID = 0;
        string _empNum = "";
        DateTime _empDate = DateTime.Now;
        DateTime? _termDate = null;
        string _lName = "";
        string _fName = "";
        DateTime _birthDate = DateTime.Now;

        [DataMember]
        public int EmployeeId
        {
            get { return _empID; }
            set { _empID = value; }
        }

        [DataMember]
        public int PersonId
        {
            get { return _persID; }
            set { _persID = value; }
        }

        [DataMember]
        public string EmployeeNumber
        {
            get { return _empNum; }
            set { _empNum = value; }
        }

        [DataMember]
        public DateTime EmployedDate
        {
            get { return _empDate; }
            set { _empDate = value; }
        }

        [DataMember]
        public DateTime? TerminatedDate
        {
            get { return _termDate; }
            set { _termDate = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _lName; }
            set { _lName = value; }
        }

        [DataMember]
        public string FirstName
        {
            get { return _fName; }
            set { _fName = value; }
        }

        [DataMember]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

    }
}