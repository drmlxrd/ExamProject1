using ExamProject1.ServicesList;
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
using ExamProject1.AdminAdd;
using ExamProject1.ServicesList;
using ExamProject1.Registration;

namespace ExamProject1.AdminList
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public AdminWindow()
        {
            InitializeComponent();

            Loaded += AdminWindow_Loaded;
        }
        private void AdminWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Services.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Services.Local.ToObservableCollection();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Services? user = ServiceList.SelectedItem as Services;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            AdminAddWindow AdminAdd = new AdminAddWindow(new Services
            {
                Price = user.Price,
                Name = user.Name
            });

            if (AdminAdd.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Services.Find(AdminAdd.Services.Price);
                if (user != null)
                {
                    user.Price = AdminAdd.Services.Price;
                    user.Name = AdminAdd.Services.Name;
                    db.SaveChanges();
                    ServiceList.Items.Refresh();
                }
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
             AdminAddWindow AdminAdd = new AdminAddWindow(new Services());
            if (AdminAdd.ShowDialog() == true)
            {
                Services services = AdminAdd.Services;
                db.Services.Add(services);
                db.SaveChanges();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var Del = ServiceList.SelectedItem as Services;
                db.Services.Remove(Del);
                db.SaveChanges();
                ServiceList.ItemsSource = db.Services.ToList();
                MessageBox.Show("Успешно");
            }
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window2 = new RegistrationWindow();
            window2.ShowDialog();
        }
    }
}
