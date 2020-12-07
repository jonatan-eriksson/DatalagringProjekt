using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Database;
using MahApps.Metro.Controls;


namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow //Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            NameBox.Focus();
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameBox.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Password)) { 
                State.User = API.LoginCustomer(NameBox.Text, PasswordBox.Password);


                if (State.User != null)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    //NameBox.Text = "";
                    PasswordBox.Password = "";
                }
            }
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
