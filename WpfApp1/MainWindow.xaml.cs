using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WpfLibrary1;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private readonly PokeClient _pokeClient;
		private readonly PokemonCoordinator _pokemonCoordinator;
		private readonly ITrainerCoordinator _trainerCoordinator;

		public MainWindow(ITrainerCoordinator trainerCoordinator, IViewModelFactory<TrainerVM> factory, PokemonCoordinator pokemonCoordinator)
		{
			InitializeComponent();
			_trainerCoordinator = trainerCoordinator;
			_pokeClient = new PokeClient();
			drpdwnAddPokemon.SelectionChanged += DrpdwnAddPokemon_SelectionChanged;
			Add.Click += Add_Click;
			PokemonCoordinator = pokemonCoordinator;
			Task.Factory.StartNew(async () => await PokemonCoordinator.Initialize());
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			if (_trainerCoordinator.CurrentTrainer == null || drpdwnAddPokemon.SelectedItem is not Pokemon pokemon)
			{
				return;
			}

			_trainerCoordinator.CurrentTrainer.Party.Add(pokemon);
		}

		private void DrpdwnAddPokemon_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (drpdwnAddPokemon.SelectedItem is Pokemon pokemon)
			{
				pokemonDetails.Text = pokemon.ToString();
			}
		}

		public PokemonCoordinator PokemonCoordinator { get; }

		public void NotifyPropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}

		public Trainer? CurrentTrainer => _trainerCoordinator.CurrentTrainer;
	}
}