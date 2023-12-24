using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PokemonDetails.xaml
    /// </summary>
    public partial class PokemonDetails : UserControl
    {
        public static readonly DependencyProperty PokemonContentsProperty = DependencyProperty.Register(
            name: "Pokemon",
            propertyType: typeof(ObservableCollection<Pokemon>),
            ownerType: typeof(PokemonDetails),
            typeMetadata: new FrameworkPropertyMetadata(OnCollectionChanged));

        public PokemonDetails()
        {
            InitializeComponent();
            SetValue(PokemonContentsProperty, new ObservableCollection<Pokemon>());
        }

        public static void OnCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue as List<Pokemon>;
        }

        public ObservableCollection<Pokemon> Pokemon
        {
            get => (ObservableCollection<Pokemon>)GetValue(PokemonContentsProperty);
            set => SetValue(PokemonContentsProperty, value);
        }
    }
}
