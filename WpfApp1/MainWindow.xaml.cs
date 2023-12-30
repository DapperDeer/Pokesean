using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        private readonly ITrainerCoordinator _trainerCoordinator;

        public MainWindow(ITrainerCoordinator trainerCoordinator, PokemonVM pokemonVM)
        {
            InitializeComponent();
            DataContext = this;
            _trainerCoordinator = trainerCoordinator;
            PokemonVM = pokemonVM;
        }

        public void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Trainer? CurrentTrainer
        {
            get { return _currentTrainer; }
            set
            {
                if (_trainerCoordinator.CurrentTrainer != value)
                {
                    _trainerCoordinator.LoadTrainer();
                    _currentTrainer = _trainerCoordinator.CurrentTrainer;
                    NotifyPropertyChanged();
                }
            }
        }
        private Trainer? _currentTrainer;

        public PokemonVM PokemonVM { get; set; }
	}
}