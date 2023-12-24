using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfLibrary1
{
	public interface IPokemonCoordinator
	{
		event PropertyChangedEventHandler? PropertyChanged;

		Task Initialize();

		ObservableCollection<Pokemon> Pokemon { get; }
	}

	public class PokemonCoordinator : IPokemonCoordinator, INotifyPropertyChanged
	{
		private readonly IPokeClient _pokeClient;
		private readonly IDesignTimeDbContextFactory<PokemonDBContext> _dbContextFactory;

		public event PropertyChangedEventHandler? PropertyChanged;

		public PokemonCoordinator(IPokeClient pokeClient, IDesignTimeDbContextFactory<PokemonDBContext> dbContextFactory)
		{
			_pokeClient = pokeClient;
			_dbContextFactory = dbContextFactory;
		}

		public async Task Initialize()
		{
			await GetAllPokemon();
		}

		private async Task GetAllPokemon()
		{
			using PokemonDBContext pokemonDBContext = _dbContextFactory.CreateDbContext();
			try
			{
				if (!pokemonDBContext.Database.EnsureCreated())
				{
					Pokemon = new ObservableCollection<Pokemon>(pokemonDBContext.Pokemon.Include(pkmn => pkmn.Type));
					return;
				}

				Pokemon = new ObservableCollection<Pokemon>(await _pokeClient.GetAllPokemon());
				await pokemonDBContext.AddRangeAsync(Pokemon!);
				await pokemonDBContext.SaveChangesAsync();
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public List<Pokemon> GetPokemon() => _pokemon.ToList();

		public ObservableCollection<Pokemon> Pokemon
		{
			get { return _pokemon; }
			set
			{
				if (_pokemon != value)
				{
					_pokemon = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pokemon)));
				}
			}
		}
		private ObservableCollection<Pokemon> _pokemon;
	}
}