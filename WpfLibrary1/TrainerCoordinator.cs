using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace WpfLibrary1
{
	public class TrainerCoordinator : ITrainerCoordinator
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private readonly OpenFileDialog _open;
		private bool _isLoading;

		public TrainerCoordinator()
		{
			_open = new OpenFileDialog();
			_open.FileOk += OnFileOk;
		}

		public Trainer NewTrainer(string name)
		{
			var trainer = new Trainer(name);
			CurrentTrainer = trainer;
			return CurrentTrainer;
		}

		public Trainer? LoadTrainer()
		{
			_isLoading = true;
			_open.ShowDialog();
			return CurrentTrainer;
		}

		private void OnFileOk(object sender, CancelEventArgs e)
		{
			if (sender is not OpenFileDialog dialog)
			{
				return;
			}

			string json = File.ReadAllText(dialog.FileName);
			var trainer = JsonSerializer.Deserialize<Trainer>(json);
			if (trainer is not null && !e.Cancel)
			{
				CurrentTrainer = trainer;
				_isLoading = false;
			}
		}

		public void UpdateTrainerCard(Trainer trainer)
		{
			if (!_isLoading)
			{
				using StreamWriter file = File.CreateText($"{trainer.Name}.json");
				JsonSerializer.Serialize(file.BaseStream, trainer);
			}
		}

		public Trainer? CurrentTrainer { get; set; }
	}
}
