using System.Windows;
using System.Windows.Controls;

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
	}
}
