using System.Data;
using System.ServiceModel;
using Acme.Service.DataContracts;

namespace Acme.Service
{
    [ServiceContract]
    public interface IAcmeService
    {
        [OperationContract]
        string AddEmployee(Employee emp);
        [OperationContract]
        DataSet GetEmployees();
        [OperationContract]
        string DeleteEmployee(Employee emp);
        [OperationContract]
        DataSet SearchEmployee(Employee emp);
        [OperationContract]
        string UpdateEmployee(Employee emp);
    }    
}
