using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PokeAPI;

namespace PokeDnD
{
	public class PokeClient : IPokeClient
	{
		public PokeClient()
		{
		}

		public async Task<Pokemon> GetPokemon(int dexNumber)
		{
			var result = await DataFetcher.GetApiObject<PokeAPI.Pokemon>(dexNumber);
			return new Pokemon
			{
				Name = result.Name,
				PokedexNumber = result.ID
			};
		}
	}
}
