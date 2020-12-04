using System;
using System.Collections.Generic;
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

namespace Store.Controls
{
    /// <summary>
    /// Interaction logic for MovieCard.xaml
    /// </summary>
    public partial class MovieCard : UserControl
    {
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            "Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MovieCard));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value);}
            remove { RemoveHandler(ClickEvent, value);}
        }

        void RaiseClickEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MovieCard.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        void OnClick()
        {
            RaiseClickEvent();
        }

        public MovieCard()
        {
            PreviewMouseLeftButtonUp += (sender, args) => OnClick();
            InitializeComponent();
        }
    }
}
