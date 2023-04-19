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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            UsersDataGrid.ItemsSource = Helper.context.Users.ToList();
        }

        private void BtnRemove_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is Users user)
            {
                Helper.context.Users.Remove(user);
                Helper.context.SaveChanges();
                Load();
            }
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            new AddOrUpdateWindow().ShowDialog();
            Load();
        }

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is Users user)
            {
                new AddOrUpdateWindow(user).ShowDialog();
                Load();
            }
        }
    }
}
