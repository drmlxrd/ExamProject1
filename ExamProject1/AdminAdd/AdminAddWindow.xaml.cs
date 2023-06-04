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
using ExamProject1.ServicesList;

namespace ExamProject1.AdminAdd
{
    /// <summary>
    /// Логика взаимодействия для AdminAddWindow.xaml
    /// </summary>
    public partial class AdminAddWindow : Window
    {
        public Services Services { get; set; }
        public AdminAddWindow(Services services)
        {
            Services = services;
            DataContext = Services;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
