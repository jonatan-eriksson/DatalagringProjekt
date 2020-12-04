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
using Database;

namespace Store.Views
{
    /// <summary>
    /// Interaction logic for UserMoviesView.xaml
    /// </summary>
    public partial class MovieUserView : UserControl
    {
        public MovieUserView()
        {
            InitializeComponent();
            State.User = API.GetCustomerByUsername("demo");
            //State.Movies = API.GetCustomerMovies(State.User);
            //icMovieList.ItemsSource = State.Movies;
        }
    }
}
