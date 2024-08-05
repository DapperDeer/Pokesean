using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel;

namespace WpfLibrary1
{
    public interface IPokemonCoordinator
	{
		event PropertyChangedEventHandler? PropertyChanged;

		Task GetAllPokemon();
		IEnumerable<Pokemon>? Pokemon { get; }
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

		public async Task GetAllPokemon()
		{
			using PokemonDBContext pokemonDBContext = _dbContextFactory.CreateDbContext();
			try
			{
				if (!pokemonDBContext.Database.EnsureCreated() && pokemonDBContext.Pokemon.Any())
				{
					Pokemon = new List<Pokemon>(pokemonDBContext.Pokemon.Include(pkmn => pkmn.Type));
				}
				else
				{
					Pokemon = new List<Pokemon>(await _pokeClient.GetAllPokemon());
					await pokemonDBContext.AddRangeAsync(Pokemon!);
					await pokemonDBContext.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pokemon)));
		}

		public IEnumerable<Pokemon>? Pokemon { get; private set; } 
	}
}