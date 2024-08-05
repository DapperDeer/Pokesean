using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1
{
	internal class PokemonSortingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is not ListSortDirection)
			{
				return "";
			}

			switch (value)
			{
				case ListSortDirection.Ascending:
					return "Sort by Ascending";
				case ListSortDirection.Descending:
					return "Sort by Descending";
			}

			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	internal class ReverseBoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool val)
			{
				return !val;
			}

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
