using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmsLINQ
{
    public class Employee
    {
        public Employee(int v1, string v2, string v3, string v4, int v5)
        {
            empId = v1;
            emp_name = v2;
            job_title = v3;
            phone_number = v4;
            salary = v5;
        }

        public int empId { get; set; }
        public string emp_name { get; set; }
        public string job_title { get; set; }
        public string phone_number { get; set; }
        public int salary { get; set; }

        public int EmpId { get; }
        public string Emp_name { get; }
        public string Job_title { get; }
        public string Phone_number { get; }
        public int Salary { get; }
    }
}
