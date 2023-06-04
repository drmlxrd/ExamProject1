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
using ExamProject1.AdminList;
using ExamProject1.ClientList;

namespace ExamProject1.Start
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminwindow = new AdminWindow();
            adminwindow.ShowDialog();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientwindow = new ClientWindow();
            clientwindow.ShowDialog();
        }
    }
}
