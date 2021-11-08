using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_2
{
    static class Extension
    {
        
        public static double income(this factory f, double contribution)
        {

            double count_of_masters = 0;
            double com_sal_of_masters = 0;
            double count_of_workers = 0;
            double inc = 0;
            if ((f.masters_salary + 10 * f.workers_salary) <= contribution)
            {
                count_of_masters = Math.Ceiling(contribution / (double)(f.masters_salary + 10 * f.workers_salary));
                com_sal_of_masters = count_of_masters * f.masters_salary;
                count_of_workers = Math.Ceiling((contribution - com_sal_of_masters) / f.workers_salary);

                inc = count_of_masters * f.profit_per_masters + count_of_workers * f.profit_per_workers;

                return inc;
            }
            else if (contribution >= f.masters_salary + f.workers_salary)
            {
                count_of_workers = Math.Floor((contribution - f.masters_salary) / (double)f.workers_salary);

                inc = f.profit_per_masters + count_of_workers * f.profit_per_workers;

                return inc;
            }
            else
            {
                return contribution;
            }

        }
    }
}
