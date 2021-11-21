using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33333
{
    public class process
    {
        public string proc_name { get; set; }
        public string proc_user { get; set; }
        public double proc_cpu { get; set; }
        public int proc_memory { get; set; }
        public string proc_location { get; set; }
        public string proc_description { get; set; }
        public int proc_priority { get; set; }
   
        public process()
        {
        
        }
        public process(string proc_name, string proc_user, double proc_cpu, int proc_memory,
                        string proc_location, string proc_description, int proc_priority)
        {
            this.proc_name = proc_name;
            this.proc_user = proc_user;
            this.proc_cpu = proc_cpu;
            this.proc_memory = proc_memory;
            this.proc_location = proc_location;
            this.proc_description = proc_description;
            this.proc_priority = proc_priority;
        }

        public process(process copy_proc)
        {
            this.proc_name = copy_proc.proc_name;
            this.proc_user = copy_proc.proc_user;
            this.proc_cpu = copy_proc.proc_cpu;
            this.proc_memory = copy_proc.proc_memory;
            this.proc_location = copy_proc.proc_location;
            this.proc_description = copy_proc.proc_description;
            this.proc_priority = copy_proc.proc_priority;
        }

        public static process operator ++(process proc)
        {
            if (proc.proc_priority < 4)
            {
                proc.proc_priority += 1;
                return proc;
            }
            else
            {
                return proc;
            }
        }
        public static process operator --(process proc)
        {
            if (proc.proc_priority > 0)
            {
                proc.proc_priority -= 1;
                return proc;
            }
            else
            {
                return proc;
            }
        }
    }
}
