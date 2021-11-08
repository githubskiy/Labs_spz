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



namespace Lb_2
{
    /// <summary>
    /// Interaction logic for FactoryReg.xaml
    /// </summary>
    public partial class FactoryReg : Window
    {
        private Dictionary<string, factory> zavod;

        public FactoryReg(Dictionary<string, factory> zavod)
        {
            this.zavod = zavod;
            InitializeComponent();
        }


        private void Button_Rg_Click(object sender, RoutedEventArgs e)
        {
            string factory_name = txtFactoryName.Text;
            int number_of_workshops;
            int number_of_workers;
            int number_of_masters;
            int workers_salary;
            int masters_salary;
            int profit_per_workers;
            int profit_per_masters;

            bool number_of_workshops_b = int.TryParse(txtNumberWorkshop.Text, out number_of_workshops);

            bool number_of_workers_b = int.TryParse(txtNumberWorkers.Text, out number_of_workers);
            bool number_of_masters_b = int.TryParse(txtNumberMasters.Text, out number_of_masters);

            bool workers_salary_b = int.TryParse(txtWorkersSalary.Text, out workers_salary);
            bool masters_salary_b = int.TryParse(txtMastersSalary.Text, out masters_salary);

            bool profit_per_workers_b = int.TryParse(txtWorkersProfit.Text, out profit_per_workers);
            bool profit_per_masters_b = int.TryParse(txtMastersProfit.Text, out profit_per_masters);

            bool has_already = zavod.ContainsKey(txtFactoryName.Text);

            if (has_already)
            {
                txtFactoryName.ToolTip = "Error! This name is already present";
                txtFactoryName.Background = Brushes.Red;

            }
            else
            {
                txtFactoryName.Background = Brushes.WhiteSmoke;
            }

            if (!number_of_workshops_b)
            {
                txtNumberWorkshop.ToolTip = "Error!";
                txtNumberWorkshop.Background = Brushes.Red;
            }
            else
            {
                txtNumberWorkshop.Background = Brushes.WhiteSmoke;
            }

            if (!number_of_workers_b)
            {
                txtNumberWorkers.ToolTip = "Error!";
                txtNumberWorkers.Background = Brushes.Red;
            }
            else
            {
                txtNumberWorkers.Background = Brushes.WhiteSmoke;
            }

            if (!number_of_masters_b)
            {
                txtNumberMasters.ToolTip = "Error!";
                txtNumberMasters.Background = Brushes.Red;
            }
            else
            {
                txtNumberMasters.Background = Brushes.WhiteSmoke;
            }

            if (!workers_salary_b)
            {
                txtWorkersSalary.ToolTip = "Error!";
                txtWorkersSalary.Background = Brushes.Red;
            }
            else
            {
                txtWorkersSalary.Background = Brushes.WhiteSmoke;
            }

            if (!masters_salary_b)
            {
                txtMastersSalary.ToolTip = "Error!";
                txtMastersSalary.Background = Brushes.Red;
            }
            else
            {
                txtMastersSalary.Background = Brushes.WhiteSmoke;
            }

            if (!profit_per_workers_b)
            {
                txtWorkersProfit.ToolTip = "Error!";
                txtWorkersProfit.Background = Brushes.Red;
            }
            else
            {
                txtWorkersProfit.Background = Brushes.WhiteSmoke;
            }

            if (!profit_per_masters_b)
            {
                txtMastersProfit.ToolTip = "Error!";
                txtMastersProfit.Background = Brushes.Red;
            }
            else
            {
                txtMastersProfit.Background = Brushes.WhiteSmoke;
            }


            if (number_of_workshops_b && number_of_workers_b && number_of_masters_b && workers_salary_b && masters_salary_b && profit_per_workers_b && profit_per_masters_b && !has_already)
            {       
                zavod.Add(factory_name, new factory(factory_name, number_of_workshops, number_of_workers, number_of_masters,
                                                    workers_salary, masters_salary, profit_per_workers, profit_per_masters));
                MessageBox.Show(zavod[factory_name].factory_name + " добавлен");
            }
            else
            {
                MessageBox.Show("Проверьте ввод");
            }
        }
    }
}
