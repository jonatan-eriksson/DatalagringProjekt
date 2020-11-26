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
            InitializeComponent();
          
        }
        
        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.InvokedItem;

            if (!e.IsItemOptions && this.HamburgerMenuControl.IsPaneOpen)
            {
                // close the menu if a item was selected
                // this.HamburgerMenuControl.IsPaneOpen = false;
            }

            
        }
        private void GoFilmer_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Filmer";
            Filmer.Visibility = Visibility.Visible;
            Konto.Visibility = Visibility.Hidden;
            MinaFilmer.Visibility = Visibility.Hidden;
            Om.Visibility = Visibility.Hidden;
            Inställningar.Visibility = Visibility.Hidden;
        }

        private void GoKonto_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Konto";
            Filmer.Visibility = Visibility.Hidden;
            Konto.Visibility = Visibility.Visible;
            MinaFilmer.Visibility = Visibility.Hidden;
            Om.Visibility = Visibility.Hidden;
            Inställningar.Visibility = Visibility.Hidden;
        }

        private void GoMinaFilmer_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Mina Filmer";
            Filmer.Visibility = Visibility.Hidden;
            Konto.Visibility = Visibility.Hidden;
            MinaFilmer.Visibility = Visibility.Visible;
            Om.Visibility = Visibility.Hidden;
            Inställningar.Visibility = Visibility.Hidden;
        }
        private void GoOm_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Om";
            Filmer.Visibility = Visibility.Hidden;
            Konto.Visibility = Visibility.Hidden;
            MinaFilmer.Visibility = Visibility.Hidden;
            Om.Visibility = Visibility.Visible;
            Inställningar.Visibility = Visibility.Hidden;
        }
        private void GoInställningar_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Store";
            Filmer.Visibility = Visibility.Visible;
            Konto.Visibility = Visibility.Hidden;
            MinaFilmer.Visibility = Visibility.Hidden;
            Om.Visibility = Visibility.Hidden;
            Inställningar.Visibility = Visibility.Visible;
        }
        

    }
}

