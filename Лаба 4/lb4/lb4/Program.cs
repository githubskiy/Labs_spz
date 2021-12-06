using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lb4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\unknown\Desktop\test.txt";

            List<double> temp_list = new List<double>();
            double num_double;
            double temp_min, temp_max;
            int ind_min, ind_max;
            using (StreamReader stream_read = new StreamReader(path, false))
            {
                string numbers = stream_read.ReadToEnd();

                foreach (var number in numbers.Split())
                {
                    if(double.TryParse(number, out num_double))
                    {
                        temp_list.Add(num_double);
                    } 
                }
            }
           
            temp_min = temp_list[temp_list.IndexOf(temp_list.Min())];
            temp_max= temp_list[temp_list.IndexOf(temp_list.Max())];

            ind_min = temp_list.IndexOf(temp_list.Min());
            ind_max = temp_list.IndexOf(temp_list.Max());

            temp_list[ind_min] = temp_max;
            temp_list[ind_max] = temp_min;

            using (StreamWriter stream = new StreamWriter(path, false))
            {
                foreach(double var in temp_list)
                {
                    stream.Write(var.ToString()+ " ");
                }
                stream.Write("\n \nЧто изменилось? \nЧисло '" + temp_min.ToString() + 
                            "' поменялось местами с числом '" + temp_max.ToString() + "'");
            }
        }
    }
}
