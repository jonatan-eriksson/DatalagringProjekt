using System;
using System.Text;
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
            State.UserMovies = API.GetCustomerMovies(State.User);
            State.Movies = API.GetMovieSlice(0, 50);

            InitializeComponent();
            
            this.HamburgerMenuControl.IsPaneOpen = true;
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

