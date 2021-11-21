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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;

namespace _33333
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window  
    {
        private Dictionary<string, computer> asus = new Dictionary<string, computer>();

        private BindingList<process> list_processs = new BindingList<process>();
        private computer_manager stas;
        DataGrid dg;

        public int ind_row;
        
        public MainWindow(computer_manager stas)
        {
            this.stas = stas;

            InitializeComponent();


        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Computer_list.SelectedIndex = (sender as ComboBox).SelectedIndex;

            if (Computer_list.ItemsSource != null && Computer_list.SelectedIndex != -1)
            {
                tableProcess.ItemsSource = stas.comp_list[Computer_list.SelectedIndex].proc_list;
                count_proc_bottom.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list.Count.ToString();

                using_ram_bottom.Text = ((stas.comp_list[Computer_list.SelectedIndex].use_ram / stas.comp_list[Computer_list.SelectedIndex].comp_ram) * 100).ToString() ;
                load_cpu_bottom.Text = (stas.comp_list[Computer_list.SelectedIndex].use_cpu_load / stas.comp_list[Computer_list.SelectedIndex].cpu_count).ToString();
            }
            
        }

        private void Button_Click_Add_Proc(object sender, RoutedEventArgs e)
        {
            if (Computer_list.SelectedIndex != -1)
            {
                create_proc create_process = new create_proc(stas, tableProcess, Computer_list, count_proc_bottom, using_ram_bottom, load_cpu_bottom);
                create_process.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите нужный компьютер из Combobox!!!");
            }
           
        }
        private void tableProcess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             dg = sender as DataGrid;

            if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1 && Computer_list.SelectedIndex != -1)
            {
                DataRowView dr = dg.SelectedItem as DataRowView;
                ind_row = dg.SelectedIndex;

                change_process change_proc = new change_process(stas, tableProcess, Computer_list, ind_row, using_ram_bottom, load_cpu_bottom);
                change_proc.ShowDialog();
            }
        }

        private void tableProcess_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
             dg = sender as DataGrid;

            if (dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
            {
                ind_row = dg.SelectedIndex;
            }
        }

        private void Button_Click_Change_Proc(object sender, RoutedEventArgs e)
        {
            if (Computer_list.SelectedIndex != -1 && dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1)
            {
                change_process change_proc = new change_process(stas, tableProcess, Computer_list, ind_row, using_ram_bottom, load_cpu_bottom);
                change_proc.ShowDialog();
            }
            else
            {
                if (Computer_list.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите нужный компьютер из Combobox!!!");
                }
                else
                {
                    MessageBox.Show("Чтобы изменить - выберите процесс!!!");
                }
            }

        }
        
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            add_comp add_computer = new add_comp(stas, Computer_list);
            add_computer.Show();
       
        }
        private void Button_Click_Del_Proc(object sender, RoutedEventArgs e)
        {
             
            if (Computer_list.SelectedIndex != -1 && dg != null && dg.SelectedItems != null && dg.SelectedItems.Count == 1 )
            {
                stas.comp_list[Computer_list.SelectedIndex].use_ram -= stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row].proc_memory;
                using_ram_bottom.Text = ((stas.comp_list[Computer_list.SelectedIndex].use_ram / stas.comp_list[Computer_list.SelectedIndex].comp_ram) * 100).ToString();

                stas.comp_list[Computer_list.SelectedIndex].remove_process(stas.comp_list[Computer_list.SelectedIndex].proc_list[ind_row]);
                tableProcess.ItemsSource = null;

                tableProcess.ItemsSource = stas.comp_list[Computer_list.SelectedIndex].proc_list;
                count_proc_bottom.Text = stas.comp_list[Computer_list.SelectedIndex].proc_list.Count.ToString();
                load_cpu_bottom.Text = "0";
            }
            else
            {
                if (Computer_list.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите нужный компьютер из Combobox!!!");
                }
                else
                {
                    MessageBox.Show("Чтобы удалить - выберите процесс!!!");
                }
            }
        }

        private void Button_Click_Remove_Computer(object sender, RoutedEventArgs e)
        {
            if (Computer_list.SelectedIndex != -1)
            {
                stas.remove_computer(stas.comp_list[Computer_list.SelectedIndex]);
                tableProcess.ItemsSource = null;

                Computer_list.ItemsSource = null;
                Computer_list.ItemsSource = stas.comp_list;

                load_cpu_bottom.Text = "0";
                count_proc_bottom.Text = "0";
                using_ram_bottom.Text =  "0";
            }
            else
            {
                MessageBox.Show("Чтобы удалить - выберите компьютер!!!");
            }
        }
        
        private void Button_Click_Change_Comp(object sender, RoutedEventArgs e)
        {
            if (Computer_list.SelectedIndex != -1)
            {
                change_comp chng_computer = new change_comp(stas, Computer_list, tableProcess, using_ram_bottom, load_cpu_bottom, ind_row);
                chng_computer.Show();
            }
            else
            {
                MessageBox.Show("Чтобы изменить - выберите компьютер!!!");
            }
        }
    }
}
