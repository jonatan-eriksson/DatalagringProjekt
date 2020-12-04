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

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            State.User = API.GetCustomerByUsername(NameBox.Text);

            if (State.User != null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                NameBox.Text = "";
            }
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
