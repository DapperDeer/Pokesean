using PokeDnD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PokeDnD_UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private PokeClient _client;
		private ComboBox _box;

		public App()
		{

			this._client = new PokeClient();
			this._box = new ComboBox();
		}
	}
}
