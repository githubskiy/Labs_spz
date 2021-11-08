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


namespace Lb_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        static Dictionary<string, factory> zavod = new Dictionary<string, factory>();
        public MainWindow()
        {

            InitializeComponent();

        }
       
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
           
            FactoryReg factory_Reg = new FactoryReg(zavod);
            factory_Reg.ShowDialog();
        }

        private void Button_Mng_Click(object sender, RoutedEventArgs e)
        {
         
            MangFactory factory_Mng = new MangFactory(zavod);
            factory_Mng.ShowDialog();   
        }
    }
}
