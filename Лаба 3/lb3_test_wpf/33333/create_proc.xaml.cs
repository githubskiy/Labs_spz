using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace _33333
{
    /// <summary>
    /// Interaction logic for create_proc.xaml
    /// </summary>
    public partial class create_proc : Window
    {

        private computer_manager stas;

        private DataGrid tableProcess;
        private ComboBox Computer_list;
        private TextBlock count_proc_bottom, using_ram_bottom;
        private TextBlock load_cpu_bottom;

        public create_proc(computer_manager stas, DataGrid tableProcess, ComboBox Computer_list, TextBlock count_proc_bottom, TextBlock using_ram_bottom, TextBlock load_cpu_bottom)
        {
            this.load_cpu_bottom = load_cpu_bottom;
            this.using_ram_bottom = using_ram_bottom;
            this.count_proc_bottom = count_proc_bottom;
            this.Computer_list = Computer_list;
            this.stas = stas;
            this.tableProcess = tableProcess;
            InitializeComponent();
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
    
            int p_memory;
            double p_cpu;
            int p_priority;
            string p_name = txtProcName.Text;
            string p_usr = txtProcUser.Text;
          
            string p_location = txtProcLocation.Text;
            string p_describe = txtProcDescribe.Text;
           

            bool p_prior = int.TryParse(txtProcPriority.Text, out p_priority);
            bool p_cpu_b = double.TryParse(txtProcCpu.Text, out p_cpu);
            bool p_mem = int.TryParse(txtProcMemory.Text, out p_memory);

            if (p_cpu_b && (p_cpu > 0) && (p_cpu < 100))
            {
                txtProcCpu.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtProcCpu.Background = Brushes.Red;
                txtProcCpu.ToolTip = "Введите корректный средний процент использования процессора";
            }

            if (p_prior && (p_priority >= 0) && (p_priority <= 4))
            {
                txtProcPriority.Background = Brushes.WhiteSmoke;

            }
            else
            {
                txtProcPriority.Background = Brushes.Red;
                txtProcPriority.ToolTip = "Введите приоритет от 0 до 4 !!!";
                
            }

            if (((stas.comp_list[Computer_list.SelectedIndex].use_ram + p_memory) <= stas.comp_list[Computer_list.SelectedIndex].comp_ram) && p_mem)
            {
                txtProcMemory.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtProcMemory.Background = Brushes.Red;
                txtProcMemory.ToolTip ="Невозможно добавить данный процесс. Недостаточно оперативной памяти или введено не целочисленный тип !!!";
            }




            if ((stas.comp_list[Computer_list.SelectedIndex].use_ram + p_memory) <= stas.comp_list[Computer_list.SelectedIndex].comp_ram && p_prior && (p_priority >= 0) && (p_priority <= 4)
                  && p_cpu_b && (p_cpu > 0) && (p_cpu < 100) && (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load + p_cpu / stas.comp_list[Computer_list.SelectedIndex].cpu_count) <= 100)
            {
                
                process curr_proc = new process(p_name, p_usr, p_cpu, p_memory, p_location, p_describe, p_priority);


                stas.comp_list[Computer_list.SelectedIndex].add_process(curr_proc);

                tableProcess.ItemsSource = stas.comp_list[Computer_list.SelectedIndex].proc_list;
                count_proc_bottom.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list.Count.ToString();
                stas.comp_list[Computer_list.SelectedIndex].use_ram += p_memory;

                stas.comp_list[Computer_list.SelectedIndex].use_cpu_load += p_cpu;



                load_cpu_bottom.Text = (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load  / stas.comp_list[Computer_list.SelectedIndex].cpu_count).ToString();

                using_ram_bottom.Text = ((stas.comp_list[Computer_list.SelectedIndex].use_ram / stas.comp_list[Computer_list.SelectedIndex].comp_ram) * 100).ToString();
                MessageBox.Show("Процесс добавлен успешно !!!");
            }
            else
            {
                if((stas.comp_list[Computer_list.SelectedIndex].use_cpu_load + p_cpu / stas.comp_list[Computer_list.SelectedIndex].cpu_count) <= 100)
                {
                    MessageBox.Show("Невозможно добавить процесс, недостаточно вычислительной мощности!!!");
                }
                else
                {
                    MessageBox.Show("Проверьте ввод данных !!!");
                }
                
            }
            
        }
   
    }
}
