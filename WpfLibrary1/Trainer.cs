using System.Text;
using System.Text.Json.Serialization;

namespace WpfLibrary1
{
	public class Trainer
	{
		[JsonConstructor]
		public Trainer(string name)
		{
			Name = name;
			Party = new List<Pokemon>(6);
			PokemonBank = new List<Pokemon>();
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Name: {Name}");
			if (Party.Any())
			{
				sb.AppendLine($"Pokemon in Party:");
				for (int i = 0; i < Party.Count; i++)
				{
					sb.AppendLine($"{i + 1}. {Party[i]}");
				}
			}
			else
			{
				sb.AppendLine("This trainer has no Pokemon.");
			}

			if (PokemonBank.Any())
			{
				sb.AppendLine($"Pokemon in Storage: ");
				foreach (var pokemon in PokemonBank)
				{
					sb.AppendLine(pokemon.ToShortString());
				}
			}
			else
			{
				sb.Append("This trainer has no Pokemon in their bank.");
			}

			return sb.ToString();
		}

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[JsonPropertyName("Party")]
		public List<Pokemon> Party { get; set; }

		[JsonPropertyName("Owned Pokemon")]
		private List<Pokemon> PokemonBank { get; }
	}
}
