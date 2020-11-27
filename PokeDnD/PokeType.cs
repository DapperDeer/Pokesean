using System;
using Newtonsoft.Json;

namespace PokeDnD
{
	public class PokeType
	{
		public enum Types
		{
			Normal, Fight, Flying,
			Poison, Ground, Rock,
			Bug, Ghost, Steel,
			Fire, Water, Grass,
			Electric, Psychic, Ice,
			Dragon, Dark, Fairy
		}

		[JsonProperty("Typing")]
		public string[] Typing { get; set; }
		public string StrongAgainst { get; }
		public string WeakAgainst { get; }

		public override string ToString()
		{
			if (this.Typing.Length > 1)
				return this.Typing[0].ToString() + " " + this.Typing[1].ToString();
			else
				return this.Typing[0].ToString();
		}
	}
}
