using PokeApiNet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Media.Imaging;

namespace WpfLibrary1
{
	[Table("Pokemon")]
	public class Pokemon
	{
		private Pokemon()
		{
		}

		public Pokemon(string name, int dexNumber, IEnumerable<PokemonType> types, IEnumerable<PokemonStat> stats, Uri imageSource)
		{
			var nameArray = name.ToCharArray();
			nameArray[0] = char.ToUpper(nameArray[0]);
			Name = string.Concat(nameArray);
			PokedexNumber = dexNumber;
			Type = PokeTypeUtilities.PokeTypeConverter(types);
			foreach (var stat in stats)
			{
				switch (stat.Stat.Name)
				{
					case "hp":
						HP = stat.BaseStat;
						continue;
					case "attack":
						Attack = stat.BaseStat;
						continue;
					case "defense":
						Defense = stat.BaseStat;
						continue;
					case "special-attack":
						SpecialAttack = stat.BaseStat;
						continue;
					case "special-defense":
						SpecialDefense = stat.BaseStat;
						continue;
					case "speed":
						Speed = stat.BaseStat;
						continue;
				}
			}
			ImageSource = new BitmapImage(imageSource);
		}

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[Key]
		[JsonPropertyName("Pokedex Number")]
		public int PokedexNumber { get; set; }

		[ForeignKey(nameof(PokeType.Id))]
		[JsonPropertyName("Type")]
		public PokeType Type { get; set; }

		public BitmapImage ImageSource { get; set; }

		public int HP { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int SpecialAttack { get; set; }
		public int SpecialDefense { get; set; }
		public int Speed { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append($"{this.Name} - {this.Type.SlotOne}");
			if (Type.SlotTwo != Types.None)
			{
				sb.Append($" - {Type.SlotTwo}");
			}
			sb.AppendLine();
			sb.AppendLine($"HP: {HP.ToString()}");
			sb.AppendLine($"Attack: {Attack.ToString()}");
			sb.AppendLine($"Defense: {Defense.ToString()}");
			sb.AppendLine($"Special Attack: {SpecialAttack.ToString()}");
			sb.AppendLine($"Special Defense: {SpecialDefense.ToString()}");
			sb.AppendLine($"Speed: {Speed.ToString()}");
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
