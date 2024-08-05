using WpfLibrary1;

namespace WpfApp1
{
	public class PokemonFilterVM : BaseVM
	{
		private readonly IPokemonFilter _filter;

		public PokemonFilterVM()
		{
			_filter = new PokemonFilter();
			PropertyChanged += OnPokemonFilterChanged;
		}

		public Types TypeOne
		{
			get => _typeOne;
			set
			{
				_typeOne = value;
				NotifyPropertyChanged();
			}
		}
		private Types _typeOne = Types.None;

		public Types TypeTwo
		{
			get => _typeTwo;
			set
			{
				_typeTwo = value;
				NotifyPropertyChanged();
			}
		}
		private Types _typeTwo = Types.None;

		public bool MonotypesOnly
		{
			get => _monotypesOnly;
			set
			{
				_monotypesOnly = value;
				NotifyPropertyChanged();
			}
		}
		private bool _monotypesOnly;

		private void OnPokemonFilterChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			_filter.OnPokemonFilterChanged(this, new PokemonFilterEventArgs(_monotypesOnly, _typeOne, _typeTwo));
		}

		public bool PassesFilter(Pokemon pokemon)
		{
			return _filter.PassesFilter(pokemon);
		}
	}
}
