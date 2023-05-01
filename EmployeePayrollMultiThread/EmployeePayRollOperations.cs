using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThread
{
    public class EmployeePayRollOperations
    {
        public List<EmployeeDetails> employeePayrollDetailsList = new List<EmployeeDetails>();
        public List<EmployeeDetails> employeePayrollDetailsListThread = new List<EmployeeDetails>();
       
        // UC1- Without Use of Thread
        
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.Name);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollDetailsList.Count());
        }
        public void AddEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailsList.Add(emp);
        }
        // UC2 With Use of Thread
        
        public void AddEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataListThread)
        {
            employeePayrollDataListThread.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    this.AddEmployeePayrollWithThread(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.Name);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailsList.Count);
        }
        public void AddEmployeePayrollWithThread(EmployeeDetails emp)
        {
            employeePayrollDetailsListThread.Add(emp);
        }
    }
}
