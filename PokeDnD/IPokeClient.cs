using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDnD
{
	interface IPokeClient
	{
		public Task<Pokemon> GetPokemon(int dexNumber);
	}
}
