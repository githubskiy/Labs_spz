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
    /// Interaction logic for change_comp.xaml
    /// </summary>
    public partial class change_comp : Window
    {
        private computer_manager stas;
        private ComboBox Computer_list;
        private DataGrid tableProcess;
        private TextBlock using_ram_bottom;
        private TextBlock load_cpu_bottom;

        double load_cpu_bottom_this_ggc;
        double load_cpu_bottom_this_per;
        private int ind_row;
        double cpu_freq;
        public change_comp(computer_manager stas, ComboBox Computer_list, DataGrid tableProcess, TextBlock using_ram_bottom, TextBlock load_cpu_bottom, int ind_row)
        {
            this.ind_row = ind_row;
            this.load_cpu_bottom = load_cpu_bottom;
            this.using_ram_bottom = using_ram_bottom;
            this.tableProcess = tableProcess;
            this.stas = stas;
            this.Computer_list = Computer_list;
            InitializeComponent();
        }

        private void Button_Click_Chng_Comp(object sender, RoutedEventArgs e)
        {

            int curr_for_slct_ind = 0;
            int copm_ram;
                int count_processors;
               
            bool cpu_freq_b = double.TryParse(txtChastota.Text, out cpu_freq);
            bool count_processors_b = int.TryParse(txtCountProcessors.Text, out count_processors);
            bool copm_ram_b = int.TryParse(txtRAM.Text, out copm_ram);

            if (copm_ram_b && copm_ram > 0)
            {
                txtRAM.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtRAM.Background = Brushes.Red;
                txtRAM.ToolTip = "Обьем оперативки должен быть положительным и целым !!!";
            }

            if (cpu_freq_b && (cpu_freq > 0) &&(cpu_freq <= 4))
            {
                txtChastota.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtChastota.Background = Brushes.Red;
                txtChastota.ToolTip = "Частота процессора должна быть положительная и не более 4ГГц !!!";
            }

            if (count_processors_b && (count_processors >= 1) && (count_processors<=5))
            {
                txtCountProcessors.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtCountProcessors.Background = Brushes.Red;
                txtCountProcessors.ToolTip = "Количество процессоров должено быть положительным целым и не более 5шт !!!";
            }

            if ((copm_ram_b && copm_ram > 0) && (cpu_freq_b && (cpu_freq > 0) && (cpu_freq <= 4)) && count_processors_b && (count_processors >= 1) && (count_processors <= 5)
                && (load_cpu_bottom_this_ggc * 100 / cpu_freq / stas.comp_list[Computer_list.SelectedIndex].cpu_count) <= 100)
            {
                stas.comp_list[Computer_list.SelectedIndex].comp_name = txtCompName.Text;
                stas.comp_list[Computer_list.SelectedIndex].comp_ram = copm_ram;
                stas.comp_list[Computer_list.SelectedIndex].cpu_frequency = cpu_freq;
                stas.comp_list[Computer_list.SelectedIndex].cpu_count = count_processors;

                tableProcess.ItemsSource = null;
                tableProcess.ItemsSource = stas.comp_list[Computer_list.SelectedIndex].proc_list;

                curr_for_slct_ind = Computer_list.SelectedIndex;
                Computer_list.ItemsSource = null;
                Computer_list.ItemsSource = stas.comp_list;

                Computer_list.SelectedIndex = curr_for_slct_ind;
                Computer_list.SelectedItem = stas.comp_list[Computer_list.SelectedIndex].comp_name;

                using_ram_bottom.Text = ((stas.comp_list[Computer_list.SelectedIndex].use_ram / stas.comp_list[Computer_list.SelectedIndex].comp_ram) * 100).ToString();
       
                stas.comp_list[Computer_list.SelectedIndex].use_cpu_load = load_cpu_bottom_this_ggc * 100 / cpu_freq;
            
                load_cpu_bottom.Text = (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load / stas.comp_list[Computer_list.SelectedIndex].cpu_count).ToString();

                MessageBox.Show("Компьютер изменен успешно !!!");
                Close();
            }
            else
            {
                if((load_cpu_bottom_this_ggc * 100 / cpu_freq / stas.comp_list[Computer_list.SelectedIndex].cpu_count) < 100)
                {
                    MessageBox.Show("Недостаточно ресурсов процессора, увеличте количество ЦП или попробуйте разогнать !!!");
                }
                else
                {
                    MessageBox.Show("Проверьте ввод данных !!!");
                }
               
            }
            
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

            txtCompName.Text = stas.comp_list[Computer_list.SelectedIndex].comp_name;
            txtRAM.Text = stas.comp_list[Computer_list.SelectedIndex].comp_ram.ToString();
            txtChastota.Text = stas.comp_list[Computer_list.SelectedIndex].cpu_frequency.ToString();
             txtCountProcessors.Text = stas.comp_list[Computer_list.SelectedIndex].cpu_count.ToString();

            double.TryParse(load_cpu_bottom.Text, out load_cpu_bottom_this_per);
            load_cpu_bottom_this_ggc = stas.comp_list[Computer_list.SelectedIndex].cpu_frequency * stas.comp_list[Computer_list.SelectedIndex].use_cpu_load / 100;
        }

        private void Button_Click_App_Freq(object sender, RoutedEventArgs e)
        {
            double cpu_freq;
            double.TryParse(txtChastota.Text, out cpu_freq);
            stas.comp_list[Computer_list.SelectedIndex].cpu_frequency = cpu_freq;
            txtChastota.Text = stas.comp_list[Computer_list.SelectedIndex].incrase_clock_frequency(0.1).ToString();
        }
        private void Button_Click_Nerf_Freq(object sender, RoutedEventArgs e)
        {
            double cpu_freq;
            double.TryParse(txtChastota.Text, out cpu_freq);
            stas.comp_list[Computer_list.SelectedIndex].cpu_frequency = cpu_freq;
            txtChastota.Text = stas.comp_list[Computer_list.SelectedIndex].decrease_clock_frequency(0.1).ToString();
        }

        private void Button_Click_Add_Processor(object sender, RoutedEventArgs e)
        {

            stas.comp_list[Computer_list.SelectedIndex].add_processor();
            txtCountProcessors.Text = stas.comp_list[Computer_list.SelectedIndex].cpu_count.ToString();
        }

        private void Button_Click_Remove_Processor(object sender, RoutedEventArgs e)
        {

            stas.comp_list[Computer_list.SelectedIndex].remove_processor();    
            txtCountProcessors.Text = stas.comp_list[Computer_list.SelectedIndex].cpu_count.ToString();
        }   
    }
}
