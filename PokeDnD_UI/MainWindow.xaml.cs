using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using PokeDnD;

namespace PokeDnD_UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private App _app;
		private OpenFileDialog _open;

		public MainWindow()
		{
			InitializeComponent();
			_app = new App();
			this._open = new OpenFileDialog();
			this._open.FileOk += (sender, e) => Trainer.LoadTrainerCard(sender, e, txtTrainerDetails);
		}

		private void btnUpdateTrainerCard_Click(object sender, RoutedEventArgs e)
		{
		}

		private void btnLoadTrainerCard_Click(object sender, RoutedEventArgs e)
		{
			this._open.InitialDirectory = Directory.GetCurrentDirectory();
			this._open.ShowDialog();
		}

		private void btnNewTrainerCard_Click(object sender, RoutedEventArgs e)
		{
			var trainer = new Trainer(txtTrainerName.Text);
		}

		//private async void Button_Click(object sender, RoutedEventArgs e)
		//{
		//	var num = Convert.ToInt32(this.txtDexInput.Text);
		//	try
		//	{
		//		var pokemon = await this._client.GetPokemon(num);
		//		lblPokemon.Content = pokemon.Name + " " + pokemon.PokedexNumber;
		//	}
		//	catch (HttpRequestException)
		//	{
		//		lblPokemon.Content = "MISSINGNO!?";

		//	}

		//}
	}
}
