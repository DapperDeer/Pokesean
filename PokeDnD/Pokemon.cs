using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PokeDnD
{
	public class Pokemon
	{
		public Pokemon()
		{
		}

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Pokedex Number")]
		public int PokedexNumber { get; set; }

		[JsonProperty("Type")]
		public PokeType Type { get; set; }

		[JsonProperty("Stats")]
		public List<Stat> Stats { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"{this.Name} - {this.Type.ToString()}");
			sb.AppendLine($"Stats:");
			foreach (var stat in this.Stats)
			{
				sb.AppendLine($"{stat.ToString()}");
			}
			return sb.ToString();
		}
	}
}
