using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Ekzamen.Data
{
    internal class UserTask
    {
        static readonly user02Entities db = new user02Entities();
        public static user02Entities OpenDb { get { return db; } set { } }
        public static void UpdateUser(user currentUser)
        {
            try
            {
                OpenDb.users.AddOrUpdate(currentUser);
                OpenDb.SaveChanges();
                MessageBox.Show("Пользователь успешно обновлен");
            }
            catch { MessageBox.Show("Ошибка редактирования пользователя"); }

        }
        public static void DeleteUser(user currentUser)
        {
            try
            {
                OpenDb.users.Remove(currentUser);
                OpenDb.SaveChanges();
                MessageBox.Show("Пользователь успешно удален");
            }
            catch {MessageBox.Show("Ошибка удаления пользователя");}
           
        }
        public static void SafeUser(user currentUser)
        {
            try
            {
                OpenDb.users.Add(currentUser);
                OpenDb.SaveChanges();
                MessageBox.Show("Пользователь успешно добавлен");
            }
            catch { MessageBox.Show("Ошибка добавления пользователя"); }

        }
    }
}
