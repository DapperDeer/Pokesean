using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokeDnD
{
	public class Stat
	{
		[JsonProperty("HP")]
		public int HP;

		[JsonProperty("Attack")]
		public int Attack;

		[JsonProperty("Defense")]
		public int Defense;

		[JsonProperty("SpAttack")]
		public int SpAttack;

		[JsonProperty("SpDefense")]
		public int SpDefense;

		[JsonProperty("Speed")]
		public int Speed;

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"HP: {this.HP}");
			sb.AppendLine($"Attack: {this.Attack}");
			sb.AppendLine($"Defense: {this.Defense}");
			sb.AppendLine($"SpAttack: {this.SpAttack}");
			sb.AppendLine($"SpDefense: {this.SpDefense}");
			sb.AppendLine($"Speed: {this.Speed}");
			return sb.ToString();
		}
	}
}
