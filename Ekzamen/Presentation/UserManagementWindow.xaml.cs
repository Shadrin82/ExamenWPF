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
using Ekzamen.Data;

namespace Ekzamen.Presentation
{
    /// <summary>
    /// Логика взаимодействия для UserManagementWindow.xaml
    /// </summary>
    public partial class UserManagementWindow : Window
    {
        user safeUser = new user();       
        public user updateUser;       
        public UserManagementWindow()
        {
            InitializeComponent();
            this.DataContext = safeUser;
            CbRole.ItemsSource = UserTask.OpenDb.userroles.ToList(); 
        }
        public UserManagementWindow(user updateUser)
        {
            InitializeComponent();
            CbRole.ItemsSource = UserTask.OpenDb.userroles.ToList();
            this.updateUser = updateUser;
            this.DataContext = updateUser;           
            CbRole.Text = updateUser.userrole.namerole.ToString();           
        }

        private void BtnSafeOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (updateUser == null)
            {
                safeUser.userroleid = (int)CbRole.SelectedValue;
                UserTask.SafeUser(safeUser);
                this.Close();
            } 
            else
            {
                updateUser.userroleid = (int)CbRole.SelectedValue;              
                UserTask.UpdateUser(updateUser);
                this.Close();
            }
               
        }
    }
}
