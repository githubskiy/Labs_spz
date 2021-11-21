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
    /// Interaction logic for autenfication.xaml
    /// </summary>
    public partial class autenfication : Window
    {
        computer_manager stas = new computer_manager(); 

        public autenfication()
        {
            InitializeComponent();
        }

        private void Button_Click_Entry(object sender, RoutedEventArgs e)
        {
            stas.admin_name = "admin";
            stas.admin_password = "admin";

            if (stas.admin_authentication(txtAdmName.Text, txtAdmPasswd.Password))
            {
               
                MainWindow m_v = new MainWindow(stas);
                m_v.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Имя пользователя или пароль неверны");
            }       
        }
    }
}
