using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1
{
	public abstract class BaseVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		public BaseVM()
		{
			Commands = [];
		}

		public virtual void NotifyPropertyChanged([CallerMemberName] string name = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}

		public Dictionary<string, ICommand> Commands { get; set; }
	}
}
