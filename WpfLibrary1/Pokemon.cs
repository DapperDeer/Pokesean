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

		public Pokemon(string name, int dexNumber, IEnumerable<PokemonType> types, IEnumerable<PokemonStat> stats)
		{
			var nameArray = name.ToCharArray();
			nameArray[0] = char.ToUpper(nameArray[0]);
			Name = string.Concat(nameArray);
			PokedexNumber = dexNumber;
			Type = PokeTypeUtilities.PokeTypeConverter(types);
			Stats = StatsConverter.ConvertToStats(stats);
		}

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[Key]
		[JsonPropertyName("Pokedex Number")]
		public int PokedexNumber { get; set; }

		[ForeignKey(nameof(PokeType.Id))]
		[JsonPropertyName("Type")]
		public PokeType Type { get; set; }

		[ForeignKey(nameof(Stats.Id))]
		[JsonPropertyName("Stats")]
		public Stats Stats { get; set; }

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
			sb.AppendLine(Stats.HP.ToString());
			sb.AppendLine(Stats.Attack.ToString());
			sb.AppendLine(Stats.Defense.ToString());
			sb.AppendLine(Stats.SpecialAttack.ToString());
			sb.AppendLine(Stats.SpecialDefense.ToString());
			sb.AppendLine(Stats.Speed.ToString());
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
