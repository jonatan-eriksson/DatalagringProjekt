using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Store.Controls;

namespace Store.Views
{
    /// <summary>
    /// Interaction logic for UserMoviesView.xaml
    /// </summary>
    public partial class MovieUserView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Movie> _userMovieList;
        //public ObservableCollection<Movie> UserMovieList { get { return _userMovieList; } set { _userMovieList = value; NotifyPropertyChanged(); } }
        public ObservableCollection<Movie> UserMovieList { get { return _userMovieList; } set { _userMovieList = value; NotifyPropertyChanged(); } }
        public List<MovieBar.CbItem> CbSortItems { get; set; }
        public List<Genre> CbGenreItems { get; set; }

        public MovieUserView()
        {
            DataContext = this;
            InitializeComponent();

            UserMovieList = new ObservableCollection<Movie>(State.UserMovies);

            CbSortItems = new List<MovieBar.CbItem>() {
                new MovieBar.CbItem() { Id=0, Name="A-Ö" },
                new MovieBar.CbItem() { Id=1, Name="Ö-A" },
                new MovieBar.CbItem() { Id=2, Name="Årtal" },
                new MovieBar.CbItem() { Id=3, Name="Högst betyg" },
                new MovieBar.CbItem() { Id=4, Name="Lägst betyg" }
            };

            CbGenreItems = new List<Genre>(API.GetGenres().OrderBy(g => g.Name));
            CbGenreItems.Insert(0, new Genre() { Id = 999, Name = "Genre" });

            cMovieBar.SearchBox.Visibility = Visibility.Hidden;
        }

        private void CMovieBar_OnComboBoxSelectionChanged(object sender, MovieBar.ComboBoxSelectionChangedEventArgs e)
        {
            if (e.SortItem is MovieBar.CbItem)
            {
                var selected = (MovieBar.CbItem)e.SortItem;

                switch (selected.Id)
                {
                    case 0: // A - Ö
                        {
                            UserMovieList = new ObservableCollection<Movie>(UserMovieList.OrderBy(a => a.Title));
                            break;
                        }
                    case 1: // Ö - A
                        {
                            UserMovieList = new ObservableCollection<Movie>(UserMovieList.OrderByDescending(a => a.Title));
                            break;
                        }
                    case 2: // Årtal
                        {
                            UserMovieList = new ObservableCollection<Movie>(UserMovieList.OrderByDescending(a => a.Year));
                            break;
                        }
                    case 3: // Högst betyg
                        {
                            UserMovieList = new ObservableCollection<Movie>(UserMovieList.OrderByDescending(a => a.Rating));
                            break;
                        }
                    case 4: // Lägst betyg
                        {
                            UserMovieList = new ObservableCollection<Movie>(UserMovieList.OrderBy(a => a.Rating));
                            break;
                        }
                }
            }
            if (e.GenreItem is Genre)
            {
                var selected = (Genre)e.GenreItem;

                // återställ MovieList om Genre väljs
                if (selected.Name == "Genre")
                    UserMovieList = new ObservableCollection<Movie>(State.UserMovies);
                else
                    UserMovieList = new ObservableCollection<Movie>(API.GetCustomerMoviesByGenre(State.User, selected));

            }
        }

        public void UserMovieListRefresh()
        {
            if (State.MoviePick != null)
            {
                State.UserMovies = API.GetCustomerMovies(State.User).OrderBy(m => m.Title).ToList();
                UserMovieList = new ObservableCollection<Movie>(State.UserMovies);
                
                // Reset moviebar
                cMovieBar.cbGenre.SelectedIndex = 0;
                cMovieBar.cbSort.SelectedIndex = 0;

                State.MoviePick = null;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserMovieListRefresh();
        }
    }
}
