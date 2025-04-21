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
namespace Ekzamen.Rpesentation
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string userName;
        string password;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            userName = TbLogin.Text;
            password = PbPassword.Password;
            Login(userName,password);
        }
        private void Login(string userName,string password )
        {    
            user currentUser = UserTask.OpenDb.users.FirstOrDefault(u => u.Login == userName);
            if (currentUser == null) { MessageBox.Show("Такого пользоваетля не существует, или вы ввели не верные данные"); return; };
            if (currentUser.password != password) { MessageBox.Show("Не верный пароль "); return; };
            if (currentUser != null)
            {
                MessageBox.Show("Успешная авторизация");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            };
            
        }
    }
}
