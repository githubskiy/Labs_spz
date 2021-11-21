using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33333
{
    public class computer: process 
    {
        public string comp_name { get; set; }
        public int comp_ram { get; set; }

        public BindingList<process> proc_list = new BindingList<process>();
        public double cpu_frequency { get; set; }
        public int cpu_count { get; set; }

        public double use_ram { get; set; }
        public double use_cpu_load { get; set; }
        public computer()
        {
            
        }
        public computer(string comp_name, int comp_ram,
                        double cpu_frequency, int cpu_count)
        {
            this.comp_name = comp_name;
            this.comp_ram = comp_ram;

            this.cpu_frequency = cpu_frequency;
            this.cpu_count = cpu_count;
        }
       
        public void change_ram(int comp_ram)
        {
            this.comp_ram = comp_ram;
        }

        public double incrase_clock_frequency(double value)
        {
            cpu_frequency += value;
            return cpu_frequency;
        }
        public double decrease_clock_frequency(double value)
        {
            cpu_frequency -= value;
            return cpu_frequency;
        }

        public void add_process(process proc)
        {
            proc_list.Add(proc );
        }
        public void remove_process(process proc)
        {
            proc_list.Remove(proc);
        }

        public void add_processor()
        {
            cpu_count += 1;
           
        }
        public void remove_processor()
        {
            cpu_count -= 1;
            
        }
    }
}
