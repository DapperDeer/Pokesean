using PokeApiNet;
using System.ComponentModel.DataAnnotations;

namespace WpfLibrary1
{
	public class Stat
	{
		public int BaseValue { get; set; }

		public string Name { get; }

		public Stat(string name, int baseValue)
		{
			Name = name;
			BaseValue = baseValue;
		}

		public override string ToString()
		{
			return $"{Name}: {BaseValue}";
		}
	}

	public static class StatsConverter
	{ 
		public static Stat Convert(PokemonStat stat, out string statName)
		{
			switch (stat.Stat.Name)
			{
				case nameof(Pokemon.HP):
					statName = nameof(Pokemon.HP);
					return new Stat(nameof(Pokemon.HP), stat.BaseStat);
				case nameof(Pokemon.Attack):
					statName = nameof(Pokemon.Attack);
					return new Stat(nameof(Pokemon.Attack), stat.BaseStat);
				case nameof(Pokemon.Defense):
					statName = nameof(Pokemon.Defense);
					return new Stat(nameof(Pokemon.Defense), stat.BaseStat);
				case nameof(Pokemon.SpecialAttack):
					statName = nameof(Pokemon.SpecialAttack);
					return new Stat(nameof(Pokemon.SpecialAttack), stat.BaseStat);
				case nameof(Pokemon.SpecialDefense):
					statName = nameof(Pokemon.SpecialDefense);
					return new Stat(nameof(Pokemon.SpecialDefense), stat.BaseStat);
				case nameof(Pokemon.Speed):
					statName = nameof(Pokemon.Speed);
					return new Stat(nameof(Pokemon.Speed), stat.BaseStat);
			}

			statName = string.Empty;
			return new Stat(string.Empty, 0);
		}

		public static Stat ConvertFromStringToStat(string str)
		{
			var parts = str.Split(':', StringSplitOptions.RemoveEmptyEntries);
			int.TryParse(parts[1].ToString(), out int baseStat);
			switch (parts[0].ToString())
			{
				case nameof(Pokemon.HP):
					return new Stat(nameof(Pokemon.HP), baseStat);
				case nameof(Pokemon.Attack):
					return new Stat(nameof(Pokemon.Attack), baseStat);
				case nameof(Pokemon.Defense):
					return new Stat(nameof(Pokemon.Defense), baseStat);
				case nameof(Pokemon.SpecialAttack):
					return new Stat(nameof(Pokemon.SpecialAttack), baseStat);
				case nameof(Pokemon.SpecialDefense):
					return new Stat(nameof(Pokemon.SpecialDefense), baseStat);
				case nameof(Pokemon.Speed):
					return new Stat(nameof(Pokemon.Speed), baseStat);
			}

			return new Stat("", 0);
		}
	}
}
