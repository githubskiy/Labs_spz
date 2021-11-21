using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for add_comp.xaml
    /// </summary>
    public partial class add_comp : Window
    {
        private computer_manager stas;

        private ComboBox Сomputer_list;

        public add_comp(computer_manager stas, ComboBox Сomputer_list) 
        {
           
            this.stas = stas;
            this.Сomputer_list = Сomputer_list;
            InitializeComponent();
        }

        private void Button_Click_Add_Comp(object sender, RoutedEventArgs e)
        {

            string CompName_ = txtCompName.Text;
            int RAM_;
            double chastota_;
            int CountCPU;
            bool RAM_B = int.TryParse(txtRAM.Text, out RAM_);
            bool chastota_b = double.TryParse(txtChastota.Text, out chastota_);
            bool CountCPU_b = int.TryParse(txtCountProcessors.Text, out CountCPU);


            if(RAM_B && RAM_ > 0)
            {
                txtRAM.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtRAM.Background = Brushes.Red;
                txtRAM.ToolTip = "Обьем оперативки должен быть положительным и целым !!!";
            }

            if (chastota_b && (chastota_ > 0) && (chastota_ <=4))
            {
                txtChastota.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtChastota.Background = Brushes.Red;
                txtChastota.ToolTip = "Частота процессора должна быть положительная и не более 4ГГц !!!";
            }

            if (CountCPU_b && (CountCPU >= 1) && (CountCPU <= 5))
            {
                txtCountProcessors.Background = Brushes.WhiteSmoke;
            }
            else
            {
                txtCountProcessors.Background = Brushes.Red;
                txtCountProcessors.ToolTip = "Количество процессоров должено быть положительным целым и не более 5шт !!!";
            }


            if ((RAM_B && RAM_ > 0) && (chastota_b && (chastota_ > 0) && (chastota_ <= 4)) && CountCPU_b && (CountCPU >= 1) && (CountCPU <= 5)) 
            {
                computer curr_comp = new computer(CompName_, RAM_, chastota_, CountCPU);
                stas.add_computer(curr_comp);

                Сomputer_list.ItemsSource = stas.comp_list;

                MessageBox.Show("Компьютер добавлен успешно !!!");
            }
            else
            {
                MessageBox.Show("Проверьте ввод данных");
            }

        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
