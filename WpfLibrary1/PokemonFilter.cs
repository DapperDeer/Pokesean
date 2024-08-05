namespace WpfLibrary1
{
	public class PokemonFilter : IPokemonFilter
	{
		private readonly TypeFilter _typeFilter = new();

		public PokemonFilter()
		{
			PokemonFilterChanged += OnPokemonFilterChanged;
		}

		public event EventHandler<PokemonFilterEventArgs>? PokemonFilterChanged;

		public void OnPokemonFilterChanged(object? sender, PokemonFilterEventArgs e)
		{
			_typeFilter.TypesToFilter = e.Types;
			_typeFilter.IsMonotype = e.IsMonoType;
		}

		public bool PassesFilter(Pokemon pokemon)
		{
			return _typeFilter.PassesFilter(pokemon);
		}

		private class TypeFilter
		{
			public Types[]? TypesToFilter { get; set; }

			public bool PassesFilter(Pokemon pokemon)
			{
				try
				{
					if (TypesToFilter is null || TypesToFilter.Length == 0)
					{
						return true;
					}

					if (TypesToFilter[0] == Types.None && TypesToFilter[1] == Types.None && !IsMonotype)
					{
						return true;
					}

					if (TypesToFilter[1] == Types.None || IsMonotype)
					{
						return pokemon.IsOfType(TypesToFilter[0], IsMonotype);
					}

					var result = pokemon.IsOfType(TypesToFilter[0]) && pokemon.IsOfType(TypesToFilter[1]);
					return result;
				}
				catch (ArgumentOutOfRangeException exception)
				{
					Console.WriteLine(exception);
					return true;
				}
			}

			public bool IsMonotype { get; set; }
		}
	}
}
