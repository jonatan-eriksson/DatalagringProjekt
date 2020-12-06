using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Store.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace Store.Views
{
    /// <summary>
    /// Interaction logic for MovieGridView.xaml
    /// </summary>
    public partial class MovieGridView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private ObservableCollection<Movie> _movieList;
        public ObservableCollection<Movie> MovieList { get { return _movieList; } set { _movieList = value; NotifyPropertyChanged(); } }
        
        public List<MovieBar.CbItem> CbSortItems { get; set; }
        public List<Genre> CbGenreItems { get; set; }

        public MovieGridView()
        {
            MovieList = new ObservableCollection<Movie>(State.Movies);
   
            CbSortItems = new List<MovieBar.CbItem>() {
                new MovieBar.CbItem() { Id=0, Name="A-Ö" },
                new MovieBar.CbItem() { Id=1, Name="Ö-A" },
                new MovieBar.CbItem() { Id=2, Name="Årtal" },
                new MovieBar.CbItem() { Id=3, Name="Högst betyg" },
                new MovieBar.CbItem() { Id=4, Name="Lägst betyg" }
            };

            CbGenreItems = new List<Genre>(API.GetGenres().OrderBy(g => g.Name));
            CbGenreItems.Insert(0, new Genre() { Id = 999, Name = "Genre" });

            DataContext = this;

            InitializeComponent();

            
        }
        
        private void MovieItem_OnClick(object sender, RoutedEventArgs e)
        {
            var mc = (MovieCard) e.OriginalSource;
            var datactx = mc.DataContext;
            State.MoviePick = (Movie) datactx;
            if (API.RegisterSale(State.User, State.MoviePick))
            {
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // MovieBar
        private void CMovieBar_OnComboBoxSelectionChanged(object sender, MovieBar.ComboBoxSelectionChangedEventArgs e)
        {
            if (e.SortItem is MovieBar.CbItem)
            {
                var selected = (MovieBar.CbItem)e.SortItem;
                
                switch (selected.Id)
                {
                    case 0: // A - Ö
                        {
                            MovieList = new ObservableCollection<Movie>(MovieList.OrderBy(a => a.Title));
                            break;
                        }
                    case 1: // Ö - A
                        {
                            MovieList = new ObservableCollection<Movie>(MovieList.OrderByDescending(a => a.Title));
                            break;
                        }
                    case 2: // Årtal
                        {
                            MovieList = new ObservableCollection<Movie>(MovieList.OrderByDescending(a => a.Year));
                            break;
                        }
                    case 3: // Högst betyg
                        {
                            MovieList = new ObservableCollection<Movie>(MovieList.OrderByDescending(a => a.Rating));
                            break;
                        }
                    case 4: // Lägst betyg
                        {
                            MovieList = new ObservableCollection<Movie>(MovieList.OrderBy(a => a.Rating));
                            break;
                        }
                }
            }
            if (e.GenreItem is Genre)
            {
                var selected = (Genre)e.GenreItem;

                // återställ MovieList om Genre väljs
                if (selected.Name == "Genre")
                    MovieList = new ObservableCollection<Movie>(State.Movies);
                else
                    MovieList = new ObservableCollection<Movie>(API.GetMoviesByGenre(selected));
                
            }
        }
        
        private void cMovieBar_SearchBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var search = cMovieBar.SearchText;
                
                if (!String.IsNullOrWhiteSpace(search))
                {
                    MovieList = new ObservableCollection<Movie>(API.GetMovieByTitle(search));
                }
                else if (MovieList.Count != State.Movies.Count)
                {
                    MovieList = new ObservableCollection<Movie>(State.Movies);
                }
            }
        }
    }
}
