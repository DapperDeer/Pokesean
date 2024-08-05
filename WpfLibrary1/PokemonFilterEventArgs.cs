namespace WpfLibrary1
{
	public class PokemonFilterEventArgs : EventArgs
	{
		public PokemonFilterEventArgs(bool isMonoType, params Types[] types)
		{
			Types = types;
			IsMonoType = isMonoType;
		}

		public Types[] Types { get; }
		public bool IsMonoType { get; }
	}
}
