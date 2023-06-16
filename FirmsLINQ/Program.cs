using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace FirmsLINQ
{
    internal class Program
    {

        static void Main(string[] args)
        {

            List<Firm> frmlist = new List<Firm>();
            Firm frm0 = new Firm(1, "Roga & Kopita", "25, 05, 1899", "IT", "Kopitin V F ", 156, "Kobiliaki");
            Firm frm1 = new Firm(2, "Food delivery", "29,11,1969", "marketing", "Dobria I M ", 299, "Lviv");
            Firm frm2 = new Firm(3, "Dizel servis", "15,10,2000", "agrotrading", "Pupkin B B ", 350, "London");
            //Firm frm3 = new Firm(4, "Tobacco chicken", "10.02.1999", "IT", " ", 50, "Ercolano");
            frmlist.Add(frm0); frmlist.Add(frm1); frmlist.Add(frm2);  //frmlist.Add(frm3);

            List<Employee> emplist = new List<Employee>();
            Employee empl0 = new Employee(1, "John", "courier", " 098 555 55 55", 7500);
            Employee empl1 = new Employee(1, "Barbara", "secretary", " 098 444 63 22", 15500);
            Employee empl2 = new Employee(3, "Lionel", "manager", " 097 123 77 11", 20100);
            Employee empl3 = new Employee(2, "Bob", "trader", " 096 777 99 82", 17900);
            Employee empl4 = new Employee(2, "Nick", "manager", " 096 656 65 65", 19900);
            emplist.Add(empl0); emplist.Add(empl1); emplist.Add(empl2); emplist.Add(empl3); emplist.Add(empl4);

            IEnumerable<Employee> query = from s in emplist                                        
                                          select s;
            Console.WriteLine("\tAll firms and Employees in firms:");
            foreach (var item in query)
            {
                Console.WriteLine($"Name: {item.emp_name}, " + $"\tJob Title: {item.job_title}, " +
                                  $"\tPhone Number: {item.phone_number}, " + $"\tSalary: {item.salary}  | " +
                                  $"\tFirm: {frmlist.First(g => g.firID == item.empId).firm_name}" +
                                  $"\tEmployees: {frmlist.First(g => g.firID == item.empId).staff_number}" +
                                  $"\tBusiness Profile: {frmlist.First(g => g.firID == item.empId).business_profile}" +
                                  $"\tCity: {frmlist.First(g => g.firID == item.empId).city}");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("фирмы, у которых в названии есть слово Food");
            IEnumerable<Firm> query2 = from s in frmlist
                                       let words = s.firm_name.Split()
                                       from item in words
                                       where item.Contains("Food")
                                       select s;
            foreach (var item in query2)
            {
                Console.Write($"\t{item.firm_name}");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("фирмы, которые работают в области маркетинга или IT");          
            IEnumerable<Firm> query3 = from s in frmlist
                                       where s.business_profile == "marketing" ||
                                       s.business_profile == "IT"
                                       select s;
            foreach (var item in query3)
            {
                Console.Write($"\t{item.firm_name}" + $" - {item.business_profile} ");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("фирмы с количеством сотрудников в диапазоне от 100 до 300");          
            IEnumerable<Firm> query4 = from i in frmlist
                                       where i.staff_number > 100 &&
                                       i.staff_number < 300
                                       select i;
            foreach (var item in query4)
            {
                Console.Write($"\t{item.firm_name}" + $" - {item.staff_number} работников");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("фирмы, которые находятся в Лондоне");
            IEnumerable<Firm> query5 = from s in frmlist
                                       where s.city == "London"                                        
                                       select s;
            foreach (var item in query5)
            {
                Console.Write($"\t{item.firm_name}" + $" from {item.city} ");
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("\nПолучить всех сотрудников фирмы \"Roga & Kopita\" ");
            IEnumerable<Firm> query6 = from s in frmlist
                                           where s.firm_name == "Roga & Kopita"
                                           select s;
            foreach (var item in query6)
            {
                Console.WriteLine($"Firm Name: {item.firm_name}, " + 
                     $"\tEmployeers: {emplist.First(g => g.empId == item.firID).emp_name}," +          // первого и послнднего получается вывести а всех нет
                     $"\t{emplist.Last(g => g.empId == item.firID).emp_name}");  
            }
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("\nПолучить сотрудников всех фирм, у которых должность менеджер ");
            IEnumerable<Employee> query7 = from s in emplist                                         
                                       where s.job_title == "manager"
                                           select s;
            foreach (var item in query7)
            {
                Console.WriteLine($"Employee Name: {item.emp_name}, " + $"Title: {item.job_title}, " +
                     $"\tFirm: {frmlist.First(g => g.firID == item.empId).firm_name},");                              
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////
            Console.WriteLine("\nПолучить сотрудников, у которых имя Lionel ");          
            IEnumerable<Employee> query8 = from s in emplist
                                           where s.emp_name == "Lionel"
                                           select s;
            foreach (var item in query8)
            {
                Console.WriteLine($"Employee Name: {item.emp_name}, " + $"Title: {item.job_title}, " +
                     $"\tFirm: {frmlist.First(g => g.firID == item.empId).firm_name},");
            }
            Console.WriteLine();
        }

    }
}
         