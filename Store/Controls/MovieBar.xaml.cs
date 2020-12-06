using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MovieBar.xaml
    /// </summary>
    public partial class MovieBar : UserControl
    {
        public MovieBar()
        {
            InitializeComponent();
        }

        // Searchbox
        public string SearchText
        {
            get { return SearchBox.Text; }
        }

        public event KeyEventHandler SearchBoxKeyDown;
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchBoxKeyDown(this, e);
        }

        // Combobox
        public event ComboBoxSelectionChangedEventHandler ComboBoxSelectionChanged;
        public delegate void ComboBoxSelectionChangedEventHandler(object sender, ComboBoxSelectionChangedEventArgs e);

        private void Genre_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ComboBoxSelectionChanged?.Invoke(this, new ComboBoxSelectionChangedEventArgs() { GenreItem = e.AddedItems[0] });
                
                if (cbSort.SelectedIndex != 0)
                    cbSort.SelectedIndex = 0;
            }
        }
        private void Sort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ComboBoxSelectionChanged?.Invoke(this, new ComboBoxSelectionChangedEventArgs() { SortItem = e.AddedItems[0] });
            }
        }
        
        public class ComboBoxSelectionChangedEventArgs : EventArgs
        {
            public Object GenreItem { get; set; }
            public Object SortItem { get; set; }
        }

        public class CbItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
