using System.ComponentModel;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PokemonDetails.xaml
    /// </summary>
    public partial class PokemonDetails : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public PokemonDetails()
        {
            InitializeComponent();
        }
    }
}
// i love you :)