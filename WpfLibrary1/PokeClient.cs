using PokeApiNet;

namespace WpfLibrary1
{
	public class PokeClient : IPokeClient
	{
		private const string GetAllPokemonUrl = @"pokemon?limit=100000&offset=0";
		private readonly PokeApiClient _client;

		public PokeClient()
		{
			_client = new PokeApiClient();
		}

		public async Task<Pokemon> GetPokemon(int dexNumber)
		{
			var pkmn = await _client.GetResourceAsync<PokeApiNet.Pokemon>(dexNumber);
			var pokemon = new Pokemon(pkmn.Name, pkmn.Id, pkmn.Types, pkmn.Stats, new Uri(pkmn.Sprites.Other.Home.FrontDefault));

			return pokemon;
		}

		public async Task<IEnumerable<Pokemon>> GetAllPokemon()
		{
			var pokemon = new List<Pokemon>();
			var result = await _client.GetNamedResourcePageAsync<PokeApiNet.Pokemon>(151, 0);
			foreach (var page in result.Results)
			{
				try
				{
					var pkmn = await _client.GetResourceAsync(page);
					pokemon.Add(new Pokemon(pkmn.Name, pkmn.Id, pkmn.Types, pkmn.Stats, new Uri(pkmn.Sprites.Other.Home.FrontDefault)));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}

			return pokemon;
		}
	}
}
