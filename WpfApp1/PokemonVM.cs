using System.Collections.ObjectModel;
using WpfLibrary1;

namespace WpfApp1
{
    public class PokemonVM : BaseVM
    {
        private readonly IPokemonCoordinator _pokemonCoordinator;

        public PokemonVM(IPokemonCoordinator pokemonCoordinator)
        {
            _pokemonCoordinator = pokemonCoordinator;
            _pokemonCoordinator.PropertyChanged += (s, e) =>
            {
                Pokemon = new ObservableCollection<Pokemon>(_pokemonCoordinator.Pokemon);
            };
            _pokemonCoordinator.GetAllPokemon().ConfigureAwait(false);
        }

        public IEnumerable<string> Types => PokeTypeUtilities.GetTypes();

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
