using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfLibrary1;

namespace WpfApp1
{
    public class PokemonVM : BaseVM
    {
        private readonly IPokemonCoordinator _pokemonCoordinator;
        private readonly ICollectionView _pokemonListBoxItems;

        public PokemonVM(IPokemonCoordinator pokemonCoordinator)
        {
            _pokemonCoordinator = pokemonCoordinator;
            _pokemonCoordinator.PropertyChanged += (s, e) =>
            {
                Pokemon = new ObservableCollection<Pokemon>(_pokemonCoordinator.Pokemon);
            };
            _pokemonCoordinator.GetAllPokemon().ConfigureAwait(false);
            _pokemonListBoxItems = CollectionViewSource.GetDefaultView(Pokemon);

            PropertyChanged += OnSelectionChanged;
            AlphabeticalSort = new RelayCommand(_ => AlphabeticalSortCommand());
            PokedexNumberSort = new RelayCommand(_ => PokedexNumberSortCommand());
        }

        private void OnSelectionChanged(object? sender, PropertyChangedEventArgs e)
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

                if (!string.IsNullOrEmpty(PokemonSearchText))
                {
                    if (!pokemon.Name.Contains(PokemonSearchText, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }
                }

                return filter.PassesFilter(pokemon);
            };
        }

        private void AlphabeticalSortCommand()
        {
            _pokemonListBoxItems.SortDescriptions.Clear();
            _pokemonListBoxItems.SortDescriptions.Add(new SortDescription(nameof(WpfLibrary1.Pokemon.Name), NameSortDirection));
            if (NameSortDirection == ListSortDirection.Ascending)
            {
                NameSortDirection = ListSortDirection.Descending;
            }
            else
            {
                NameSortDirection = ListSortDirection.Ascending;
            }
        }

        private void PokedexNumberSortCommand()
        {
            _pokemonListBoxItems.SortDescriptions.Clear();
            _pokemonListBoxItems.SortDescriptions.Add(new SortDescription(nameof(WpfLibrary1.Pokemon.PokedexNumber), PokedexSortDirection));
            if (PokedexSortDirection == ListSortDirection.Ascending)
            {
                PokedexSortDirection = ListSortDirection.Descending;
            }
            else
            {
                PokedexSortDirection = ListSortDirection.Ascending;
            }
        }

        public ListSortDirection NameSortDirection { get; set; } = ListSortDirection.Ascending;

        public ListSortDirection PokedexSortDirection { get; set; } = ListSortDirection.Ascending;

        public bool IsTypeTwoEnabled => !MonotypesOnly;

        public RelayCommand AlphabeticalSort { get; }

        public RelayCommand PokedexNumberSort { get; }

        public IEnumerable<string> Types => PokeTypeUtilities.GetTypes();

        public string PokemonSearchText
        {
            get
            {
                return _pokemonSearchText;
            }
            set
            {
                _pokemonSearchText = value;
                NotifyPropertyChanged(nameof(PokemonSearchText));
            }
        }
        private string _pokemonSearchText;

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

// MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM