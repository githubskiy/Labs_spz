using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1_spz
{
    class EmployeeException : ArgumentException
    {
        public EmployeeException(string message) : base(message) { }
    }

    class Program
    {
        static public void compareEmployee(Employee one, Employee two)
        {
            Console.WriteLine("Compare position: ");
            Console.WriteLine($"{one.fio}: {one.position} \n{two.fio}: {two.position}");
        }

        static void Main(string[] args)
        {

            Employee employee1 = new Employee("Ivanov Ivan Ivanovich", "manager", "Delta1");
            employee1.payroll();
            Console.WriteLine(employee1.ToString());
            Employee employee2 = new Employee("Petrov Petr Petrovich", "director", "Delta1");
            Console.WriteLine(employee2.ToString());
            Employee employee3 = new Employee("Pushin Vladimir Vladimirovich", "director", "Alfa1");
            Console.WriteLine(employee3.ToString());
            Employee employee4 = new Employee("Medin Dmitriy Aleksandrovich", "manager", "Alfa1");
            Console.WriteLine(employee4.ToString());
            Employee employee5 = new Employee("Leyov Dmitriy Konstantinovich", "other", "Alfa1");
            employee5.payroll();
            Console.WriteLine(employee5.ToString());

            employee1.changePosition("director");
            employee1.payroll();

            employee5.changePosition("manager");
            employee5.payroll();
            Console.WriteLine(employee5.ToString());
            employee5.changePosition("director");
            employee5.payroll();
            Console.WriteLine(employee5.ToString());
           
            employee1.showHistoryPos();
            employee5.showHistoryPos();

            employee5.changeDepartment("Delta2");
            employee5.changePosition("manager");
            employee5.showHistoryDep();
            employee5.showHistoryPos();
            employee5.searchPosition("manager");

            compareEmployee(employee1, employee5);

        }
    }
}
