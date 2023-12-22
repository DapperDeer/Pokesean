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
			var pkmnStats = new Dictionary<string, Stat>();
			foreach (var stat in stats)
			{
				var pokemonStat = StatsConverter.Convert(stat, out string statName);
				
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

		public Stat HP { get; set; } = new(nameof(HP), 0);
		public Stat Attack { get; set; } = new(nameof(Attack), 0);
		public Stat Defense { get; set; } = new(nameof(Defense), 0);
		public Stat SpecialAttack { get; set; } = new(nameof(SpecialAttack), 0);
		public Stat SpecialDefense { get; set; } = new(nameof(SpecialDefense), 0);
		public Stat Speed { get; set; } = new(nameof(Speed), 0);

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append($"{this.Name} - {this.Type.SlotOne}");
			if (Type.SlotTwo != Types.None)
			{
				sb.Append($" - {Type.SlotTwo}");
			}
			sb.AppendLine();
			sb.AppendLine(HP.ToString());
			sb.AppendLine(Attack.ToString());
			sb.AppendLine(Defense.ToString());
			sb.AppendLine(SpecialAttack.ToString());
			sb.AppendLine(SpecialDefense.ToString());
			sb.AppendLine(Speed.ToString());
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
