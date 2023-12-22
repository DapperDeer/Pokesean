using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfLibrary1.Tests
{
	[TestClass]
	public class StatsConverterTests
	{
		private static readonly Stat ExpectedHP = new Stat(nameof(Stats.HP), 46);
		private static readonly Stat ExpectedAttack = new Stat(nameof(Stats.Attack), 46);
		private static readonly Stat ExpectedDefense = new Stat(nameof(Stats.Defense), 46);
		private static readonly Stat ExpectedSpecialAttack = new Stat(nameof(Stats.SpecialAttack), 46);
		private static readonly Stat ExpectedSpecialDefense = new Stat(nameof(Stats.SpecialDefense), 46);
		private static readonly Stat ExpectedSpeed = new Stat(nameof(Stats.Speed), 46);
		private static readonly Stats ExpectedStats = new Stats 
		{
			HP = ExpectedHP,
			Attack = ExpectedAttack,
			Defense = ExpectedDefense,
			SpecialAttack = ExpectedSpecialAttack,
			SpecialDefense = ExpectedSpecialDefense,
			Speed = ExpectedSpeed,
		};

		[TestMethod]
		[DataRow("HP: 46")]
		[DataRow("Attack: 46")]
		[DataRow("Defense: 46")]
		[DataRow("SpecialAttack: 46")]
		[DataRow("SpecialDefense: 46")]
		[DataRow("Speed: 46")]
		public void ConvertFromStringTest(string stat)
		{
			var stats = StatsConverter.ConvertFromString(stat);

			Assert.IsNotNull(stats);
			Assert.IsTrue(ExpectedStats.Contains(stats));
		}
	}
}