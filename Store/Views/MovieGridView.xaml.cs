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
using Store.Models;
using Store.ViewModels;
using System.Threading.Tasks;

namespace Store.Views
{
    /// <summary>
    /// Interaction logic for MovieGridView.xaml
    /// </summary>
    public partial class MovieGridView : UserControl
    {
        public List<MovieBar.CbItem> CbSortItems { get; set; } = new List<MovieBar.CbItem>();
        public List<Genre> CbGenreItems { get; } = new List<Genre>(API.GetGenres().OrderBy(g => g.Name));
        
        //public List<Movie> MovieList { get; set; } = new List<Movie>();
        public List<Movie> MovieList { get; set; }


        public MovieGridView()
        {
            State.Movies = API.GetMovieSlice(0, 100);
            //MovieList = API.GetMovieSlice(0, 100);
            DataContext = this;
            InitializeComponent();

            // Sort combobox
            var SortItems = new MovieBar.CbItem[]
            {
                new MovieBar.CbItem() { Id=1, Name="A-Ö" },
                new MovieBar.CbItem() { Id=1, Name="Ö-A" },
                new MovieBar.CbItem() { Id=1, Name="År" },
                new MovieBar.CbItem() { Id=1, Name="Rating" } 
            };
            CbSortItems.AddRange(SortItems);
            
            //MessageBox.Show("MovieList " + MovieList.Count.ToString());
            //MessageBox.Show("Movies " + State.Movies.Count.ToString());
            
            // Genre combobox
            //var genres = API.GetGenres().OrderBy(g => g.Name);
            //cMovieBar.cbGenre.ItemsSource = genres;
            
        }

        private void MovieItem_OnClick(object sender, RoutedEventArgs e)
        {
            var mc = (MovieCard) e.OriginalSource;
            var datacxtx = mc.DataContext;
            var datasource = (Movie) datacxtx;
            MessageBox.Show(datasource.Title);
        }

        private void CMovieBar_OnComboBoxSelectionChanged(object sender, MovieBar.ComboBoxSelectionChangedEventArgs e)
        {
            if (e.SortItem is MovieBar.CbItem)
            {
                var selected = (MovieBar.CbItem)e.SortItem;

                //var sortList = MovieList.OrderBy(a => a.Title.ToLower()).ToList();
                //State.Movies.Sort((a,b) => a.Title.ToLower().CompareTo(b.Title.ToLower()));

                icMovieList.ItemsSource = MovieList;

                
            }
            if (e.GenreItem is Genre)
            {
                var selected = (Genre)e.GenreItem;
                State.Movies = API.GetMoviesByGenre(selected.Name);
                //icMovieList.ItemsSource = State.Movies;
            }
        }
    }
}
