namespace WpfLibrary1
{
	public interface IPokemonFilter
	{
		event EventHandler<PokemonFilterEventArgs>? PokemonFilterChanged;

		bool PassesFilter(Pokemon pokemon)
		{
			return true;
		}
		void OnPokemonFilterChanged(object? sender, PokemonFilterEventArgs e);
	}
}
