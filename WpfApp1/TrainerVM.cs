using WpfLibrary1;
using System.Collections.ObjectModel;

namespace WpfApp1
{
	public class TrainerVM
	{
        private readonly Trainer? _trainer;
        private readonly ITrainerCoordinator _trainerCoordinator;

        public TrainerVM(ITrainerCoordinator trainerCoordinator)
        {
            _trainerCoordinator = trainerCoordinator;
            _trainer = _trainerCoordinator.LoadTrainer();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemon.Add(pokemon);
        }

        public ObservableCollection<Pokemon> Pokemon { get; } = new();

        public Trainer? Trainer => _trainer;

		public bool CurrentTrainerLoaded => _trainerCoordinator.CurrentTrainer != null;
	}
}
