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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Servises;

namespace Lb_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\students.json";
        BindingList<student_performance> test_bind_list = new BindingList<student_performance>();
        private FileIOServise _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOServise(PATH);

            try
            {
                test_bind_list = _fileIOService.LoadData();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }
            

            students_perform.ItemsSource = test_bind_list;
            test_bind_list.ListChanged += test_bind_list_ListChanged;

        }
        
        private void test_bind_list_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || 
               e.ListChangedType == ListChangedType.ItemChanged)
            {
                
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Close();
                }
            }
        
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var index = students_perform.Columns.Single(c => c.Header.ToString() == "HeaderName").DisplayIndex;
            MessageBox.Show(index.ToString());
        }
    }
}