using Microsoft.EntityFrameworkCore;
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

namespace ExamProject1.RegClients
{
    /// <summary>
    /// Логика взаимодействия для RegClientsWindow.xaml
    /// </summary>
    public partial class RegClientsWindow : Window
    {
        ApplicationContetxBuy db = new ApplicationContetxBuy();
        public RegClientsWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Buyers.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Buyers.Local.ToObservableCollection();
        }
    }
}
