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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users = new ObservableCollection<User>();
        ObservableCollection<Admin> admins = new ObservableCollection<Admin>();
        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User { Name = "Renée Ravan", Mail = "reneeravan@hotmail.com" });
            users.Add(new User { Name = "Leila Massudi", Mail = "leilamassudi@hotmail.com" });
            users.Add(new User { Name = "Desirée Ravan", Mail = "desiree@kvillebiljard.se" });
            Users.ItemsSource = users;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = Namn.Text, Mail = Mail.Text });
            Namn.Clear();
            Mail.Clear();

        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (Users.SelectedIndex > -1)
            {
                users.RemoveAt(Users.SelectedIndex);
                RemoveUser.IsEnabled = false;
            }
            else if (Admins.SelectedIndex > -1)
            {
                admins.RemoveAt(Admins.SelectedIndex);
                RemoveUser.IsEnabled = false;
            }
            else
            {

            }
        }

        private void Promote_Click(object sender, RoutedEventArgs e)
        {
            // admins.Add(new Admin() { Name = , Mail =  });
            Admins.Items.Add(Users.SelectedItem);
            users.RemoveAt(Users.SelectedIndex);
        }

        private void Demote_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Namn.Clear();
            Mail.Clear();
            RemoveUser.IsEnabled = true;
            // Namn.Text = users.

        }
    }

    public class Admin
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}
