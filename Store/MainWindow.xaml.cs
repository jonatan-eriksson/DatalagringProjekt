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
using Database;
using MahApps.Metro.Controls;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow //Window
    {
        public MainWindow()
        {
            State.User = API.LoginCustomer("demo", "demo");
            State.Movies = API.GetMovieSlice(0, 100);
            State.UserMovies = API.GetCustomerMovies(State.User);
            InitializeComponent();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.InvokedItem;

            if (!e.IsItemOptions && this.HamburgerMenuControl.IsPaneOpen)
            {
                // close the menu if a item was selected
                this.HamburgerMenuControl.Content = e.InvokedItem;
                this.HamburgerMenuControl.IsPaneOpen = false;
            }
        }
    }
}

