using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

namespace PokeDnD
{
	class Program
	{
		private static string[] _regions =
		{
			"Kanto", "Johto", "Hoenn", "Sinnoh",
			"Unova", "Kalos", "Alola", "Galar"
		};

		static void Main(string[] args)
		{
			var _client = new PokeClient();
			string response;
			do
			{
				WriteLine("Greetings.");
				WriteLine("1. Create new trainer.");
				WriteLine("2. Load existing trainer.");
				WriteLine("3. Pokedex");
			
				response = ReadLine();
				if (response == "1")
				{
					WriteLine("Please enter your name: ");
					var name = ReadLine();
					var trainer = new Trainer(name);
					if (trainer != null)
					{
						WriteLine($"Welcome, {trainer.Name}, to the wonderful world of Pokemon!");
						WriteLine($"Which region of starters would you like to see?");
						string ans;
						do
						{
							ans = ReadLine();
						} while (!_regions.Contains(ans));

					}
				}
				else if (response == "3")
				{
					WriteLine("Please enter the dex entry to pull:");
					var num = ReadLine();
					var result = _client.GetPokemon(Convert.ToInt32(num)).Result;
					WriteLine($"{result.Name}");
					foreach (var stat in result.Stats)
					{
						WriteLine($"{stat} - {stat}");
					}
				}
			} while (response != "exit");
		}
	}
}
