using System.ComponentModel.DataAnnotations;

namespace WpfLibrary1
{
	public struct Stat
	{
		public int BaseValue { get; }

		[Key]
		public string Name { get; }

		public Stat(string name, int baseValue)
		{
			Name = name;
			BaseValue = baseValue;
		}

		public override string ToString()
		{
			return $"{Name}: {BaseValue}";
		}
	}
}
