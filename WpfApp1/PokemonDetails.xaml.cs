using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PokemonDetails.xaml
    /// </summary>
    public partial class PokemonDetails : UserControl, INotifyPropertyChanged
    {
        private bool _monotypesOnly;
        private readonly ICollectionView _pokemonListBox;

        public PokemonDetails()
        {
            InitializeComponent();
            _pokemonListBox = CollectionViewSource.GetDefaultView(PokemonListBox.Items);
            MonotypeCheckbox.Click += OnMonotypeToggle;
            TypeComboboxSlotOne.SelectionChanged += OnFiltersChanged;
            TypeComboboxSlotTwo.SelectionChanged += OnFiltersChanged;
        }

        public void OnMonotypeToggle(object sender, RoutedEventArgs e)
        {
            TypeComboboxSlotTwo.IsEnabled = _monotypesOnly;
            _monotypesOnly = !_monotypesOnly;
            OnFiltersChanged(sender, e);
            return;
        }

        public void OnFiltersChanged(object sender, RoutedEventArgs e)
        {
            _pokemonListBox.Filter = (o) =>
            {
                if (o is not Pokemon pokemon)
                {
                    throw new InvalidOperationException("Trying to filter on an object that is not a Pokemon.");
                }

                if (!Enum.TryParse<Types>((string)TypeComboboxSlotOne.SelectedItem, out var typeOne))
                {
                    typeOne = Types.None;
                }

                if (!Enum.TryParse<Types>((string)TypeComboboxSlotTwo.SelectedItem, out var typeTwo))
                {
                    typeTwo = Types.None;
                }

                var filter = PokemonFilterBuilder.BuildTypeFilter(typeOne, typeTwo, _monotypesOnly);
                return filter.PassesFilter(pokemon);
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
// i love you :)