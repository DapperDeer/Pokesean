namespace WpfLibrary1
{
	public interface ITrainerCoordinator
	{
		Trainer? CurrentTrainer { get; set; }

		Trainer NewTrainer(string name);

		Trainer? LoadTrainer();
	}
}
