using PokeApiNet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WpfLibrary1
{
	[Table("Pokemon")]
	public class Pokemon
	{
		private Pokemon()
		{
		}

		public Pokemon(string name, int dexNumber, IEnumerable<PokeApiNet.PokemonType> types, IEnumerable<PokemonStat> stats)
		{
			var nameArray = name.ToCharArray();
			nameArray[0] = char.ToUpper(nameArray[0]);
			Name = string.Concat(nameArray);
			PokedexNumber = dexNumber;
			Type = PokeTypeUtilities.PokeTypeConverter(types);
			foreach (var stat in stats)
			{
				Stats.Add(new(stat.Stat.Name, stat.BaseStat));
			}
		}

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[Key]
		[JsonPropertyName("Pokedex Number")]
		public int PokedexNumber { get; set; }

		[ForeignKey(nameof(PokeType.Id))]
		[JsonPropertyName("Type")]
		public PokeType Type { get; set; }

		[JsonPropertyName("Stats")]
		public List<Stat> Stats { get; } = new();

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append($"{this.Name} - {this.Type.SlotOne}");
			if (Type.SlotTwo != Types.None)
			{
				sb.Append($" - {Type.SlotTwo}");
			}
			sb.AppendLine();
			sb.AppendLine($"Stats:");
			foreach (var stat in this.Stats)
			{
				sb.AppendLine($"{stat}");
			}
			return sb.ToString();
		}

		public string ToShortString()
		{
			var sb = new StringBuilder();
			sb.Append($"{this.Name} - {this.Type.SlotOne}");
			if (Type.SlotTwo != Types.None)
			{
				sb.Append($" - {Type.SlotTwo}");
			}
			return sb.ToString();
		}
	}
}
