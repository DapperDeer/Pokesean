namespace WpfLibrary1
{
	public interface IPokeClient
	{
		public Task<Pokemon> GetPokemon(int dexNumber);
		public Task<IEnumerable<Pokemon>> GetAllPokemon();
	}
}
