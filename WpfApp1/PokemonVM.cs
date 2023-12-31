using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfLibrary1;

namespace WpfApp1
{
    public class PokemonVM : BaseVM
    {
        public ListSortDirection NameSortDirection = ListSortDirection.Ascending;
        public ListSortDirection PokedexSortDirection = ListSortDirection.Ascending;

        private readonly IPokemonCoordinator _pokemonCoordinator;
        private readonly ICollectionView _pokemonListBoxItems;

        public PokemonVM(IPokemonCoordinator pokemonCoordinator)
        {
            _pokemonCoordinator = pokemonCoordinator;
            _pokemonCoordinator.PropertyChanged += (s, e) =>
            {
                Pokemon = new ObservableCollection<Pokemon>(_pokemonCoordinator.Pokemon);
            };
            PropertyChanged += PokemonVM_PropertyChanged;
            _pokemonCoordinator.GetAllPokemon().ConfigureAwait(false);
            _pokemonListBoxItems = CollectionViewSource.GetDefaultView(Pokemon);
        }

        public void PokemonVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (_pokemonListBoxItems == null)
            {
                // Probably just haven't painted/initialized the ListBox yet.
                return;
            }

            _pokemonListBoxItems.Filter = (o) =>
            {
                if (o is not Pokemon pokemon)
                {
                    return false;
                }

                var filter = PokemonFilterBuilder.BuildTypeFilter(SelectedTypeOne, SelectedTypeTwo, MonotypesOnly);
                return filter.PassesFilter(pokemon);
            };
        }

        public void AlphabeticalSort(object sender, RoutedEventArgs e)
        {
            if (sender is not Button sortToggle)
            {
                return;
            }

            ChangeSortingDirection(nameof(WpfLibrary1.Pokemon.Name), ref NameSortDirection);
            sortToggle.ToolTip = $"Sort Pokemon by Name, {NameSortDirection}";
        }

        public void PokedexNumberSort(object sender, RoutedEventArgs e)
        {
            if (sender is not Button sortToggle)
            {
                return;
            }

            ChangeSortingDirection(nameof(WpfLibrary1.Pokemon.PokedexNumber), ref PokedexSortDirection);
            sortToggle.ToolTip = $"Sort Pokemon by Number, {PokedexSortDirection}";
        }

        private void ChangeSortingDirection(string propertyName, ref ListSortDirection direction)
        {
            var sortDescription = _pokemonListBoxItems.SortDescriptions.FirstOrDefault(desc => desc.PropertyName == propertyName);
            if (sortDescription != default)
            {
                _pokemonListBoxItems.SortDescriptions.Remove(sortDescription);
            }

            _pokemonListBoxItems.SortDescriptions.Add(new SortDescription(propertyName, direction));
            if (direction == ListSortDirection.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }
        }

        public IEnumerable<string> Types => PokeTypeUtilities.GetTypes();

        public bool MonotypesOnly 
        { 
            get
            {
                return _monotypesOnly;
            }
            set
            {
                _monotypesOnly = value;
                NotifyPropertyChanged(nameof(MonotypesOnly));
            }
        }
        private bool _monotypesOnly;

        public Types SelectedTypeOne
        {
            get
            {
                return _selectedTypeOne;
            }
            set
            {
                _selectedTypeOne = value;
                NotifyPropertyChanged(nameof(SelectedTypeOne));
            }
        }
        private Types _selectedTypeOne = WpfLibrary1.Types.None;

        public Types SelectedTypeTwo
        {
            get
            {
                return _selectedTypeTwo;
            }
            set
            {
                _selectedTypeTwo = value;
                NotifyPropertyChanged(nameof(SelectedTypeTwo));
            }
        }
        private Types _selectedTypeTwo = WpfLibrary1.Types.None;

        public ObservableCollection<Pokemon> Pokemon
        {
            get { return _pokemon; }
            set
            {
                if (_pokemon != value)
                {
                    _pokemon = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ObservableCollection<Pokemon> _pokemon;
    }
}
