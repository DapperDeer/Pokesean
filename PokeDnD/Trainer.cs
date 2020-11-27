using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace PokeDnD
{
	public class Trainer
	{
		public Trainer()
		{

		}

		[JsonConstructor]
		public Trainer(string name)
		{
			this.Name = name;
			this.Party = new List<Pokemon>(6);
		}

		public static void LoadTrainerCard(object sender, EventArgs args, TextBlock content)
		{
			var file = sender as OpenFileDialog;
			string json = File.ReadAllText(file.FileName);
			var trainer = JsonConvert.DeserializeObject<Trainer>(json);
			content.Text = trainer.ToString();
		}

		public void Update()
		{
			using StreamWriter file = File.CreateText($"{this.Name}.json");
			var serializer = new JsonSerializer();
			serializer.Serialize(file, this);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Name: {this.Name}");
			sb.AppendLine($"Pokemon in Party:");
			for (int i = 0; i < this.Party.Count; i++)
			{
				sb.AppendLine($"{i + 1}. {this.Party[i]}");
			}
			return sb.ToString();
		}

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Party")]
		public List<Pokemon> Party { get; set; }

		[JsonProperty("Owned Pokemon")]
		private List<Pokemon> PokemonBank { get; }
	}
}
