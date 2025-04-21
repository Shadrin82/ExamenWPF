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
using Ekzamen.Data;
using Ekzamen.Presentation;

namespace Ekzamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        user currentUser = new user();
        
        public MainWindow()
        {
            InitializeComponent();
            DgUser.ItemsSource = UserTask.OpenDb.users.ToList();
        }

        private void SafeUser_Click(object sender, RoutedEventArgs e)
        {
            UserManagementWindow userManagementWindow = new UserManagementWindow();
            userManagementWindow.ShowDialog();
            DgUser.ItemsSource = UserTask.OpenDb.users.ToList();
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            UserManagementWindow userManagementWindow = new UserManagementWindow(currentUser);
            userManagementWindow.ShowDialog();
            DgUser.ItemsSource = UserTask.OpenDb.users.ToList();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {           
            UserTask.DeleteUser(currentUser);
            DgUser.ItemsSource = UserTask.OpenDb.users.ToList();
        }

        private void DgUser_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            currentUser = DgUser.SelectedItem as user;  
        }
    }
}
