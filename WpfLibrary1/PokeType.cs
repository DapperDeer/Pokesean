using PokeApiNet;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WpfLibrary1
{
	public enum Types
	{
		Normal, Fight, Flying,
		Poison, Ground, Rock,
		Bug, Ghost, Steel,
		Fire, Water, Grass,
		Electric, Psychic, Ice,
		Dragon, Dark, Fairy, None
	}

	public class PokeType
	{
		[Key]
		public int Id { get; set; }

		[JsonPropertyName("TypeSlotOne")]
		public Types SlotOne { get; set; } = Types.None;

		[JsonPropertyName("TypeSlotTwo")]
		public Types SlotTwo { get; set; } = Types.None;

		public string StrongAgainst { get; }
		public string WeakAgainst { get; }
	}

	public static class PokeTypeUtilities
	{
		public static PokeType PokeTypeConverter(IEnumerable<PokemonType> pokemonTypes)
		{
			var type = new PokeType();
			foreach (var pokemonType in pokemonTypes)
			{
				if (pokemonType.Slot == 1)
				{
					type.SlotOne = GetType(pokemonType);
				}
				else
				{
					type.SlotTwo = GetType(pokemonType);
				}
			}

			return type;
			Types GetType(PokemonType type)
			{
				switch (type.Type.Name)
				{
					case "fight":
					case "fighting":
						return Types.Fight;
					case "flying":
						return Types.Flying;
					case "poison":
						return Types.Poison;
					case "ground":
						return Types.Ground;
					case "rock":
						return Types.Rock;
					case "bug":
						return Types.Bug;
					case "ghost":
						return Types.Ghost;
					case "steel":
						return Types.Steel;
					case "fire":
						return Types.Fire;
					case "water":
						return Types.Water;
					case "grass":
						return Types.Grass;
					case "electric":
						return Types.Electric;
					case "psychic":
						return Types.Psychic;
					case "ice":
						return Types.Ice;
					case "dragon":
						return Types.Dragon;
					case "dark":
						return Types.Dark;
					case "fairy":
						return Types.Fairy;
					case "normal":
						return Types.Normal;
					default:
						return Types.None;
				}
			}
		}
	}
}
