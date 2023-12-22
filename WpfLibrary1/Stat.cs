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

	public class Stats
	{
		[Key]
		public int Id { get; set; }
		public Stat HP { get; set; } = new(nameof(HP), 0);
		public Stat Attack { get; set; } = new(nameof(Attack), 0);
		public Stat Defense { get; set; } = new(nameof(Defense), 0);
		public Stat SpecialAttack { get; set; } = new(nameof(SpecialAttack), 0);
		public Stat SpecialDefense { get; set; } = new(nameof(SpecialDefense), 0);
		public Stat Speed { get; set; } = new(nameof(Speed), 0);

		public bool Contains(Stats stats)
		{
			return Contains(stats.HP) ||
					Contains(stats.Attack) || 
					Contains(stats.Defense) || 
					Contains(stats.SpecialAttack) ||
					Contains(stats.SpecialDefense) ||
					Contains(stats.Speed);
		}

		public bool Contains(Stat stat)
		{
			switch (stat.Name)
			{
				case nameof(HP):
					return stat.BaseValue == HP.BaseValue;
				case nameof(Attack):
					return stat.BaseValue == Attack.BaseValue;
				case nameof(Defense):
					return stat.BaseValue == Defense.BaseValue;
				case nameof(SpecialAttack):
					return stat.BaseValue == SpecialAttack.BaseValue;
				case nameof(SpecialDefense):
					return stat.BaseValue == SpecialDefense.BaseValue;
				case nameof(Speed):
					return stat.BaseValue == Speed.BaseValue;
				default:
					return false;
			}
		}
	}

	public static class StatsConverter
	{
		public static Stats ConvertToStats(IEnumerable<PokemonStat> stats)
		{
			Stats pokemonStats = new();
			foreach (var stat in stats)
			{
				switch (stat.Stat.Name)
				{
					case "hp":
						pokemonStats.HP = new Stat(nameof(Stats.HP), stat.BaseStat);
						continue;
					case "attack":
						pokemonStats.Attack = new Stat(nameof(Stats.Attack), stat.BaseStat);
						continue;
					case "defense":
						pokemonStats.Defense = new Stat(nameof(Stats.Defense), stat.BaseStat);
						continue;
					case "special-attack":
						pokemonStats.SpecialAttack = new Stat(nameof(Stats.SpecialAttack), stat.BaseStat);
						continue;
					case "special-defense":
						pokemonStats.SpecialDefense = new Stat(nameof(Stats.SpecialDefense), stat.BaseStat);
						continue;
					case "speed":
						pokemonStats.Speed = new Stat(nameof(Stats.Speed), stat.BaseStat);
						continue;
				}
			}

			return pokemonStats;
		}

		// "HP: 123"
		public static Stats ConvertFromString(string str) 
		{
			var pokemonStats = new Stats();
			var parts = str.Split(':', StringSplitOptions.RemoveEmptyEntries);
			int.TryParse(parts[1].ToString(), out int baseStat);
			switch (parts[0].ToString())
			{
				case nameof(Stats.HP):
					pokemonStats.HP = new Stat(nameof(Stats.HP), baseStat);
					break;
				case nameof(Stats.Attack):
					pokemonStats.Attack = new Stat(nameof(Stats.Attack), baseStat);
					break;
				case nameof(Stats.Defense):
					pokemonStats.Defense = new Stat(nameof(Stats.Defense), baseStat);
					break;
				case nameof(Stats.SpecialAttack):
					pokemonStats.SpecialAttack = new Stat(nameof(Stats.SpecialAttack), baseStat);
					break;
				case nameof(Stats.SpecialDefense):
					pokemonStats.SpecialDefense = new Stat(nameof(Stats.SpecialDefense), baseStat);
					break;
				case nameof(Stats.Speed):
					pokemonStats.Speed = new Stat(nameof(Stats.Speed), baseStat);
					break;
			}
			return pokemonStats;
		}

		public static Stat ConvertFromStringToStat(string str)
		{
			var parts = str.Split(':', StringSplitOptions.RemoveEmptyEntries);
			int.TryParse(parts[1].ToString(), out int baseStat);
			switch (parts[0].ToString())
			{
				case nameof(Stats.HP):
					return new Stat(nameof(Stats.HP), baseStat);
				case nameof(Stats.Attack):
					return new Stat(nameof(Stats.Attack), baseStat);
				case nameof(Stats.Defense):
					return new Stat(nameof(Stats.Defense), baseStat);
				case nameof(Stats.SpecialAttack):
					return new Stat(nameof(Stats.SpecialAttack), baseStat);
				case nameof(Stats.SpecialDefense):
					return new Stat(nameof(Stats.SpecialDefense), baseStat);
				case nameof(Stats.Speed):
					return new Stat(nameof(Stats.Speed), baseStat);
			}

			return new Stat("", 0);
		}
	}
}
