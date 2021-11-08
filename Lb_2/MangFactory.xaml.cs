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
    /// Interaction logic for MangFactory.xaml
    /// </summary>
    public partial class MangFactory : Window
    {
        private Dictionary<string, factory> zavod;
        string factory_name;
        string factory_name_for_union;
        string factory_name_for_clone;
        int number_of_workersR;
        int number_of_mastersR;
        double incinv;
        public MangFactory(Dictionary<string, factory> zavod)
        {
            this.zavod = zavod;
            InitializeComponent();
        }

        private void Button_Slct_Click(object sender, RoutedEventArgs e)
        {
            if (zavod.ContainsKey(txtFactorysName.Text))
            {
                txtFactorysName.Background = Brushes.WhiteSmoke;
                factory_name = txtFactorysName.Text;
                facName1.Text = "Название завода: " + factory_name;

                NumbWrkshp.Text = "Количество цехов: " + zavod[factory_name].number_of_workshops.ToString();

                NumbWrkrs.Text = "Количество работников: " + zavod[factory_name].number_of_workers.ToString();
                NumbMstrs.Text = "Количество мастеров: " + zavod[factory_name].number_of_masters.ToString();

                WrkrsSlr.Text = "Зарплата работника: " + zavod[factory_name].workers_salary.ToString();
                MstrsSlr.Text = "Зарплата мастера: " + zavod[factory_name].masters_salary.ToString();

                WrkrsPrft.Text = "Прибыль с одного работника: " + zavod[factory_name].profit_per_workers.ToString();
                MstrsPrft.Text = "Прибыль с одного мастера: " + zavod[factory_name].profit_per_masters.ToString();
            }
            else
            {
                txtFactorysName.ToolTip = "Error!";
                txtFactorysName.Background = Brushes.Red;
                MessageBox.Show("Нет такого завода!!!");
            }
        }

        private void Button_WNum_Hr_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtNumberWorkersR.Text, out number_of_workersR))
            {
                txtNumberWorkersR.ToolTip = "Error!";
                txtNumberWorkersR.Background = Brushes.Red;
            }
            else
            {
                txtNumberWorkersR.Background = Brushes.WhiteSmoke;

                zavod[factory_name].hiring_a_workers(number_of_workersR);
                NumbWrkrs.Text = "Количество рабочих: " + zavod[factory_name].number_of_workers.ToString();
            }      
        }

        private void Button_WNum_Fr_Click(object sender, RoutedEventArgs e)
        {
            if ((!int.TryParse(txtNumberWorkersR.Text, out number_of_workersR)) || ((zavod[factory_name].number_of_workers - number_of_workersR) < 0))
            {
                txtNumberWorkersR.ToolTip = "Error!";
                txtNumberWorkersR.Background = Brushes.Red;
                MessageBox.Show("Number of workers will be error!");
            }
            else
            {
                txtNumberWorkersR.Background = Brushes.WhiteSmoke;

                zavod[factory_name].dismissal_of_workers(number_of_workersR);
                NumbWrkrs.Text = "Количество рабочих: " + zavod[factory_name].number_of_workers.ToString();
            }
        }

        private void Button_MNum_Hr_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtNumberMastersR.Text, out number_of_mastersR))
            {
                txtNumberMastersR.ToolTip = "Error!";
                txtNumberMastersR.Background = Brushes.Red;
            }
            else
            {
                txtNumberMastersR.Background = Brushes.WhiteSmoke;

                zavod[factory_name].hiring_a_masters(number_of_mastersR);
                NumbMstrs.Text = "Количество мастеров: " + zavod[factory_name].number_of_masters.ToString();
            }      
        }

        private void Button_MNum_Fr_Click(object sender, RoutedEventArgs e)
        {
            
            if ((!int.TryParse(txtNumberMastersR.Text, out number_of_mastersR)) || ((zavod[factory_name].number_of_masters - number_of_mastersR) < 0))
            {
                txtNumberMastersR.ToolTip = "Error!";
                txtNumberMastersR.Background = Brushes.Red;
                MessageBox.Show("Number of masters will be error!");
            }
            else
            {
                txtNumberMastersR.Background = Brushes.WhiteSmoke;

                zavod[factory_name].dismissal_of_masters(number_of_mastersR);
                NumbMstrs.Text = "Количество мастеров: " + zavod[factory_name].number_of_masters.ToString();
            }
        }

        private void Button_Unn_Click(object sender, RoutedEventArgs e)
        {
            if ((!zavod.ContainsKey(txtFactoryNameUnion.Text)) || (zavod[factory_name].factory_name == txtFactoryNameUnion.Text))
            {
                txtFactoryNameUnion.ToolTip = "Error! This is the name of this factory or there is no such factory";
                txtFactoryNameUnion.Background = Brushes.Red;

                MessageBox.Show("Error! This is the name of this factory or there is no such factory");
            }
            else
            {
                txtFactoryNameUnion.Background = Brushes.WhiteSmoke;

                factory_name_for_union = txtFactoryNameUnion.Text;

                zavod[factory_name] = (zavod[factory_name] + zavod[factory_name_for_union]);
                zavod.Remove(factory_name_for_union);

                facName1.Text = "Название завода: " + factory_name;

                NumbWrkshp.Text = "Количество цехов: " + zavod[factory_name].number_of_workshops.ToString();

                NumbWrkrs.Text = "Количество рабочих: " + zavod[factory_name].number_of_workers.ToString();
                NumbMstrs.Text = "Количество мастеров: " + zavod[factory_name].number_of_masters.ToString();

                WrkrsSlr.Text = "Зарплата рабочего: " + zavod[factory_name].workers_salary.ToString();
                MstrsSlr.Text = "Зарплата мастера: " + zavod[factory_name].masters_salary.ToString();

                WrkrsPrft.Text = "Прибыль с одного работника: " + zavod[factory_name].profit_per_workers.ToString();
                MstrsPrft.Text = "Прибыль с одного мастера: " + zavod[factory_name].profit_per_masters.ToString();

            }
           
        }

        private void Button_IncInv_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtIncomeInvest.Text, out incinv))
            {
                txtIncomeInvest.ToolTip = "Error!";
                txtIncomeInvest.Background = Brushes.Red;
            }
            else
            {
                txtIncomeInvest.Background = Brushes.WhiteSmoke;

                zavod[factory_name].income(incinv);
                Inc.Text = "Доход от вклада через месяц: " + zavod[factory_name].income(incinv).ToString();
            }   
        }

        private void Button_Cln_Click(object sender, RoutedEventArgs e)
        {
            if (zavod.ContainsKey(txtFactoryNameClone.Text) || (zavod[factory_name].factory_name == txtFactoryNameClone.Text))
            {
                txtFactoryNameClone.ToolTip = "Error! This is the name of this factory or there is such a factory";
                txtFactoryNameClone.Background = Brushes.Red;
                MessageBox.Show("Error! This is the name of this factory or there is such a factory");
            }
            else
            {
                txtFactoryNameClone.Background = Brushes.WhiteSmoke;
                factory_name_for_clone = txtFactoryNameClone.Text;

                zavod.Add(factory_name_for_clone, new(zavod[factory_name]));
                zavod[factory_name_for_clone].factory_name = factory_name_for_clone;
                MessageBox.Show("Клон создан");
            }
        }

        private void Button_Cmp_Click(object sender, RoutedEventArgs e)
        {

            if (zavod[factory_name].factory_name == txtFactoryNameCompare.Text)
            {
                txtFactoryNameCompare.ToolTip = "Error! This is the name of this factory";
                txtFactoryNameCompare.Background = Brushes.Red;
                MessageBox.Show("Error! This is the name of this factory");

            }
            else
            {
                txtFactoryNameCompare.Background = Brushes.WhiteSmoke;

                if (zavod[factory_name].CompareTo(zavod[txtFactoryNameCompare.Text]) == 1)
                {
                    Cmpr.Text = "Кол. отделов " + zavod[factory_name].factory_name + " больше на " + (zavod[factory_name].number_of_workshops - zavod[txtFactoryNameCompare.Text].number_of_workshops).ToString();
                }
                else if (zavod[factory_name].CompareTo(zavod[txtFactoryNameCompare.Text]) == -1)
                {
                    Cmpr.Text = "Кол. отделов " + zavod[factory_name].factory_name + " меньше на " + (zavod[txtFactoryNameCompare.Text].number_of_workshops - zavod[factory_name].number_of_workshops).ToString();
                }
                else
                {
                    Cmpr.Text = "Одинаковое количество отделов";
                }
            }

           
        }
    }
}
