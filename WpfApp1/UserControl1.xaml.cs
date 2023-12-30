using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary1;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}

		private void btnUpdateTrainerCard_Click(object sender, RoutedEventArgs e)
		{
		}

		private void btnLoadTrainerCard_Click(object sender, RoutedEventArgs e)
		{
			//var trainer = _trainerCoordinator.LoadTrainer();
			//txtTrainerDetails.Text = trainer.ToString();
		}

		private void btnNewTrainerCard_Click(object sender, RoutedEventArgs e)
		{
			//_trainerCoordinator.NewTrainer(txtTrainerName.Text);
		}

        public Trainer Trainer
        {
            get => (Trainer)GetValue(PokemonTrainerProperty);
            set
            {
                SetValue(PokemonTrainerProperty, value);
            }
        }

        public static readonly DependencyProperty PokemonTrainerProperty = DependencyProperty.Register(
			name: "Trainer",
			propertyType: typeof(Trainer),
			ownerType: typeof(UserControl1),
			typeMetadata: new FrameworkPropertyMetadata
			{
				PropertyChangedCallback = (sender, e) =>
				{
					if (e.OldValue != e.NewValue && sender is UserControl1 trainerDetails && e.NewValue is Trainer trainer)
					{
						trainerDetails.SetCurrentValue(PokemonTrainerProperty, trainer);
					}
				}
			});
	}
}
