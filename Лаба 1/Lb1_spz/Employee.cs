using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb1_spz
{
    class Employee
    {
        public string fio;
        public string position;
        public int salary;

        public string[] history_curr;
        public string[] history;
        public string department;

        public string[] history_curr_d;
        public string[] history_d;
        public Employee(string fio, string position, string department)
        {
            if (String.Compare(fio, "") == 0)
                throw new EmployeeException("This field (Employee's first & last name) cannot be empty!");
            for (int i = 0; i < fio.Length; i++)
            {
                if (Char.IsDigit(fio, i) == true)
                    throw new EmployeeException("This field (Employee's first & last name) cannot contain digits!");
            }
            this.fio = fio;

            if (!(Equals(position, "director") || Equals(position, "manager") || Equals(position, "engeener") || Equals(position, "other")))
                throw new EmployeeException("This field (Employee's position) cannot be different with 'director'/'manager'/'engeener'/'other'!");

            this.position = position;

            bool flag_for_letter = false;
            bool flag_for_digit = false;
            if (String.Compare(department, "") == 0)
                throw new EmployeeException("This field (Employee's department) cannot be empty!");
            for (int i = 0; i < department.Length; i++)
            {
                if (Char.IsDigit(department, i) == false)
                    flag_for_digit = true;
                if ((i == department.Length - 1) && flag_for_digit == false)
                    throw new EmployeeException("This field (Employee's department) must contain digit!");
                if (Char.IsLetter(department, i) == false)
                    flag_for_letter = true;
                if ((i == department.Length - 1) && flag_for_letter == false)
                    throw new EmployeeException("This field (Employee's department) must contain letter!");
            }
            this.department = department;

            history_curr = new string[] { position };
            history_curr_d = new string[] { department };
        }
        public override string ToString()
        {
            return "FIO: " + fio + ":\n Position: " + position + "\n Department:" + department + "\n Salary: " + salary + "\n";
        }

        public void changePosition(string position)
        {
            if (!(Equals(position, "director") || Equals(position, "manager") || Equals(position, "engeener") || Equals(position, "other")))
                throw new EmployeeException("This field (Employee's position) cannot be different with 'director'/'manager'/'engeener'/'other'!");

            this.position = position;

            history = new string[history_curr.Length + 1];
            for (int i = 0; i < history.Length - 1; ++i)
                history[i] = history_curr[i];

            history[history.Length - 1] = position;
            history_curr = new string[history.Length];
            for (int i = 0; i < history.Length; ++i)
                history_curr[i] = history[i];
        }

        public void changeDepartment(string department)
        {
            bool flag_for_letter = false;
            bool flag_for_digit = false;
            if (String.Compare(department, "") == 0)
                throw new EmployeeException("This field (Employee's department) cannot be empty!");
            for (int i = 0; i < department.Length; i++)
            {
                if (Char.IsDigit(department, i) == false)
                    flag_for_digit = true;
                if ((i == department.Length - 1) && flag_for_digit == false)
                    throw new EmployeeException("This field (Employee's department) must contain digit!");

                if (Char.IsLetter(department, i) == false)
                    flag_for_letter = true;
                if ((i == department.Length - 1) && flag_for_letter == false)
                    throw new EmployeeException("This field (Employee's department) must contain letter!");
            }
            this.department = department;

            history_d = new string[history_curr_d.Length + 1];
            for (int i = 0; i < history_d.Length - 1; ++i)
                history_d[i] = history_curr_d[i];

            history_d[history_d.Length - 1] = department;
            history_curr_d = new string[history_d.Length];
            for (int i = 0; i < history_d.Length; ++i)
                history_curr_d[i] = history_d[i];
        }

        public void searchPosition(string position)
        {
            bool flag = false;
            for (int i = 0; i < history.Length; ++i)
            {
                if (history[i] == position)
                {
                    flag = true;
                    if (i == 0)
                        Console.WriteLine($"{fio} has been started working: {history[i]}");
                    else
                        Console.WriteLine($"{fio} has been changed this position {position} with: {history[i - 1]}");
                }
                else if ((i == history.Length - 1) && (flag == false))
                {
                    Console.WriteLine($"{fio} has not this position: {position}");
                }
            }
        }
        public void showHistoryPos()
        {
            Console.WriteLine($"History career's (position) changes for {fio}: ");
            for (int i = 0; i < history.Length; ++i)
                Console.WriteLine($"- {history[i]} ");
        }
        public void showHistoryDep()
        {
            Console.WriteLine($"History career's (department) changes for {fio}: ");
            for (int i = 0; i < history_d.Length; ++i)
                Console.WriteLine($"- {history_d[i]} ");
        }
        public void payroll()
        {
            if (position == "director") { salary = 50000; }
            else if (position == "manager") { salary = 20000; }
            else if (position == "engeener") { salary = 10000; }
            else if (position == "other") { salary = 5000; }
        }
    }
}
