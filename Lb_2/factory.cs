using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_2
{
    public class factory : IComparable
    {
        public string factory_name { get; set; }
        public int number_of_workshops { get; set; }

        public int number_of_workers { get; set; }
        public int number_of_masters { get; set; }

        public int workers_salary { get; set; }
        public int masters_salary { get; set; }

        public int profit_per_workers { get; set; }
        public int profit_per_masters { get; set; }



        public factory(string factory_name, int number_of_workshops, int number_of_workers, int number_of_masters,
                        int workers_salary, int masters_salary, int profit_per_workers, int profit_per_masters)
        {
            this.factory_name = factory_name;
            this.number_of_workshops = number_of_workshops;
            this.number_of_workers = number_of_workers;
            this.number_of_masters = number_of_masters;
            this.workers_salary = workers_salary;
            this.masters_salary = masters_salary;
            this.profit_per_workers = profit_per_workers;
            this.profit_per_masters = profit_per_masters;
        }

        public factory(factory f)
        {
            this.factory_name = f.factory_name;
            this.number_of_workshops = f.number_of_workshops;
            this.number_of_workers = f.number_of_workers;
            this.number_of_masters = f.number_of_masters;
            this.workers_salary = f.workers_salary;
            this.masters_salary = f.masters_salary;
            this.profit_per_workers = f.profit_per_workers;
            this.profit_per_masters = f.profit_per_masters;
        }

        public static factory operator +(factory factory1, factory factory2)
        {
            string factory_name = factory1.factory_name;
            int number_of_workshops = factory1.number_of_workshops + factory2.number_of_workshops;
            int number_of_workers = factory1.number_of_workers + factory2.number_of_workers;
            int number_of_masters = factory1.number_of_masters + factory2.number_of_masters;
            int workers_salary = (factory1.workers_salary + factory2.workers_salary) / 2;
            int masters_salary = (factory1.masters_salary + factory2.masters_salary) / 2;
            int profit_per_workers = (factory1.profit_per_workers + factory2.profit_per_workers) / 2;
            int profit_per_masters = (factory1.profit_per_masters + factory2.profit_per_masters) / 2;  

            return new factory(factory_name, number_of_workshops, number_of_workers, number_of_masters, workers_salary,
                                masters_salary, profit_per_workers, profit_per_masters);
        }

        public void hiring_a_workers(int number_hiring_a_worker)
        {
            this.number_of_workers += number_hiring_a_worker;

        }

        public void hiring_a_masters(int number_hiring_a_masters)
        {
            this.number_of_masters += number_hiring_a_masters;

        }

        public void dismissal_of_workers(int number_dismissal_of_workers)
        {
            this.number_of_workers -= number_dismissal_of_workers;
        }

        public void dismissal_of_masters(int number_dismissal_of_masters)
        {
            this.number_of_masters -= number_dismissal_of_masters;
        }

        public int CompareTo(object obj)
        {
            factory temp = (factory)obj;
            if (this.number_of_workshops > temp.number_of_workshops)
            {
                return 1;
            }
            else if (this.number_of_workshops < temp.number_of_workshops)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
