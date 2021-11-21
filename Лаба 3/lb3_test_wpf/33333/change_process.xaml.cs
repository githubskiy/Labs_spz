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

namespace _33333
{
    /// <summary>
    /// Interaction logic for change_process.xaml
    /// </summary>
    public partial class change_process : Window
    {
        private computer_manager stas;
        private DataGrid tableProcess;
        private ComboBox Computer_list;
        private int ind_row;
        private TextBlock using_ram_bottom;
        private TextBlock load_cpu_bottom;
     

        public change_process(computer_manager stas, DataGrid tableProcess, ComboBox Computer_list, int ind_row, TextBlock using_ram_bottom, TextBlock load_cpu_bottom)
        {

            this.load_cpu_bottom = load_cpu_bottom;
            this.using_ram_bottom = using_ram_bottom;
            this.stas = stas;
            this.tableProcess = tableProcess;
            this.Computer_list = Computer_list;
            this.ind_row = ind_row;
            InitializeComponent();
        }

        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {
           
           
            double p_cpu_new;

            int p_priority_new;
            int p_memory_new;



            string p_name_new = txtProcNameCng.Text;
            string p_usr_new = txtProcUserCng.Text;
            string p_location_new = txtProcLocationCng.Text;
            string p_describe_new = txtProcDescribeCng.Text;

            bool p_mem_new =   int.TryParse(txtProcMemoryCng.Text, out p_memory_new);
            bool p_prior_new =  int.TryParse(txtProcPriorityCng.Text, out p_priority_new);
            bool p_cpu_new_b = double.TryParse(txtProcCpuCng.Text, out p_cpu_new);

            

            if (p_cpu_new_b && (p_cpu_new > 0) && (p_cpu_new < 100))
            {
                txtProcCpuCng.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtProcCpuCng.Background = Brushes.Red;
                txtProcCpuCng.ToolTip = "Введите корректный средний процент использования процессора";
            }

            if (p_prior_new && (p_priority_new >= 0) && (p_priority_new <= 4))
            {
                txtProcPriorityCng.Background = Brushes.WhiteSmoke;

            }
            else
            {
                txtProcPriorityCng.Background = Brushes.Red;
                txtProcPriorityCng.ToolTip = "Введите приоритет от 0 до 4 !!!";

            }

            if (((stas.comp_list[Computer_list.SelectedIndex].use_ram + p_memory_new) <= stas.comp_list[Computer_list.SelectedIndex].comp_ram) && p_mem_new)
            {
                txtProcMemoryCng.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtProcMemoryCng.Background = Brushes.Red;
                txtProcMemoryCng.ToolTip = "Невозможно добавить данный процесс. Недостаточно оперативной памяти или введено не целочисленный тип !!!";
            }

            if ((stas.comp_list[Computer_list.SelectedIndex].use_ram + p_memory_new) <= stas.comp_list[Computer_list.SelectedIndex].comp_ram && p_prior_new && (p_priority_new >= 0) && (p_priority_new <= 4)
                && p_cpu_new_b && (p_cpu_new > 0) && (p_cpu_new < 100) && (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load + p_cpu_new / stas.comp_list[Computer_list.SelectedIndex].cpu_count) <= 100)
            {
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_name = p_name_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_user = p_usr_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_cpu = p_cpu_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_memory = p_memory_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_location = p_location_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_description = p_describe_new;
                stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_priority = p_priority_new;

                tableProcess.ItemsSource = null;
                tableProcess.ItemsSource = stas.comp_list[Computer_list.SelectedIndex].proc_list;

                stas.comp_list[Computer_list.SelectedIndex].use_ram += p_memory_new;
                stas.comp_list[Computer_list.SelectedIndex].use_cpu_load += p_cpu_new;

                using_ram_bottom.Text = ((stas.comp_list[Computer_list.SelectedIndex].use_ram / stas.comp_list[Computer_list.SelectedIndex].comp_ram) * 100).ToString();

                load_cpu_bottom.Text = (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load / stas.comp_list[Computer_list.SelectedIndex].cpu_count).ToString();

                MessageBox.Show("Процесс изменен успешно !!!");
                Close();
            }
            else
            {
                if ((stas.comp_list[Computer_list.SelectedIndex].use_cpu_load + p_cpu_new / stas.comp_list[Computer_list.SelectedIndex].cpu_count) <= 100)
                {
                    MessageBox.Show("Невозможно добавить процесс, недостаточно вычислительной мощности!!!");
                }
                else
                {
                    MessageBox.Show("Проверьте ввод данных !!!");
                }
            }
  
        }

        private void txtProcNameCng_Loaded(object sender, RoutedEventArgs e)
        {
            txtProcNameCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_name;
            txtProcUserCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_user;
            txtProcCpuCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_cpu.ToString();
            txtProcMemoryCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_memory.ToString();
            txtProcLocationCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_location;
            txtProcDescribeCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_description;
            txtProcPriorityCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_priority.ToString();

            stas.comp_list[Computer_list.SelectedIndex].use_ram -= stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_memory;
            stas.comp_list[Computer_list.SelectedIndex].use_cpu_load -= stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_cpu;

        }

        private void Button_Click_Inc_Priority(object sender, RoutedEventArgs e)
        {
            int priority;
            int.TryParse(txtProcPriorityCng.Text, out priority);
            stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_priority = priority;

            txtProcPriorityCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row]++.proc_priority.ToString();
        }
        private void Button_Click_Dec_Priority(object sender, RoutedEventArgs e)
        {
            int priority;

            int.TryParse(txtProcPriorityCng.Text, out priority);
            stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_priority = priority;

            txtProcPriorityCng.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row]--.proc_priority.ToString();
        }
    }
}
