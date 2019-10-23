using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users = new ObservableCollection<User>();
        ObservableCollection<User> admins = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User { Name = "Renée Ravan", Mail = "reneeravan@hotmail.com" });
            users.Add(new User { Name = "Leila Massudi", Mail = "leilamassudi@hotmail.com" });
            users.Add(new User { Name = "Desirée Ravan", Mail = "desiree@kvillebiljard.se" });
            admins.Add(new Admin { Name = "Karo Massudi", Mail = "karomassudi@live.se" });
            Users.ItemsSource = users;
            Admins.ItemsSource = admins;
            
        }

        public bool adminSelected = false;
        public bool userSelected = false;

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            if (AddUser.IsEnabled == true)
            {
                if (Namn.Text == "" || Mail.Text == "")
                {

                }
                else
                {
                    users.Add(new User() { Name = Namn.Text, Mail = Mail.Text });
                    Namn.Clear();
                    Mail.Clear();
                    AddUser.IsEnabled = false;
                }
            }
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (Users.SelectedIndex > -1)
            {
                users.RemoveAt(Users.SelectedIndex);
                RemoveUser.IsEnabled = false;
                ChangeUser.IsEnabled = false;
                AddUser.IsEnabled = false;
            }
            else if (Admins.SelectedIndex > -1)
            {
                admins.RemoveAt(Admins.SelectedIndex);
                RemoveUser.IsEnabled = false;
                ChangeUser.IsEnabled = false;
                AddUser.IsEnabled = false;
            }
            else
            {

            }
        }

        private void Promote_Click(object sender, RoutedEventArgs e)
        {
            if (Users.SelectedIndex > -1)
            {
                var user = users[Users.SelectedIndex];
                admins.Add(user);
                users.RemoveAt(Users.SelectedIndex);
                RemoveUser.IsEnabled = false;
                ChangeUser.IsEnabled = false;
                AddUser.IsEnabled = false;
            }
        }

        private void Demote_Click(object sender, RoutedEventArgs e)
        {
            if (Admins.SelectedIndex > -1)
            {
                var admin = admins[Admins.SelectedIndex];
                users.Add(admin);
                admins.RemoveAt(Admins.SelectedIndex);
                RemoveUser.IsEnabled = false;
                ChangeUser.IsEnabled = false;
                AddUser.IsEnabled = false;
            }
        }

        public void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Namn.Clear();
            Mail.Clear();
            userSelected = true;
            adminSelected = false;
            if (Users.SelectedIndex > -1)
            {
                var user = users[Users.SelectedIndex];
                Namn.Text = user.Name;
                Mail.Text = user.Mail;
                RemoveUser.IsEnabled = true;
                ChangeUser.IsEnabled = true;
                AddUser.IsEnabled = false;
            }
        }

        public void Admins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Namn.Clear();
            Mail.Clear();
            adminSelected = true;
            userSelected = false;
            if (Admins.SelectedIndex > -1)
            {
                var admin = admins[Admins.SelectedIndex];
                Namn.Text = admin.Name;
                Mail.Text = admin.Mail;
                RemoveUser.IsEnabled = true;
                ChangeUser.IsEnabled = true;
                AddUser.IsEnabled = false;
            }
        }

        public void ChangeUser_Click(object sender, RoutedEventArgs e)
        {            
             
            if(userSelected == true)
            {
                if (Users.SelectedIndex > -1)
                {
                    users.Add(new User { Name = Namn.Text, Mail = Mail.Text });
                    users.RemoveAt(Users.SelectedIndex);
                }
            }
            else if (adminSelected == true)
            {
                if (Admins.SelectedIndex > -1)
                {
                    admins.Add(new User { Name = Namn.Text, Mail = Mail.Text });
                    admins.RemoveAt(Admins.SelectedIndex);
                }
            }
            else
            {
                
            }
        }
       
        private void Namn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
                AddUser.IsEnabled = true;
            }
        }

        private void Namn_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddUser.IsEnabled = true;
        }

        private void Mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddUser.IsEnabled = true;
        }
    }

    public class Admin : User
    {

    }

    public class User
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
