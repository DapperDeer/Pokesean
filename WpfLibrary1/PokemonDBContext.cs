using Microsoft.EntityFrameworkCore;

namespace WpfLibrary1
{
	public class PokemonDBContext : DbContext
	{
		public DbSet<Pokemon> Pokemon { get; set; }

		public PokemonDBContext(DbContextOptions dbContextOptions)
			: base(dbContextOptions)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PokeType>()
				.Property(e => e.SlotOne)
				.HasConversion(
					e => e.ToString(),
					e => (Types)Enum.Parse(typeof(Types), e));

			modelBuilder.Entity<PokeType>()
				.Property(e => e.SlotTwo)
				.HasConversion(
					e => e.ToString(),
					e => (Types)Enum.Parse(typeof(Types), e));

			modelBuilder.Entity<Stats>()
				.Property(e => e.HP)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.HP), stat));
			modelBuilder.Entity<Stats>()
				.Property(e => e.Attack)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.Attack), stat));
			modelBuilder.Entity<Stats>()
				.Property(e => e.Defense)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.Defense), stat));
			modelBuilder.Entity<Stats>()
				.Property(e => e.SpecialAttack)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.SpecialAttack), stat));
			modelBuilder.Entity<Stats>()
				.Property(e => e.SpecialDefense)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.SpecialDefense), stat));
			modelBuilder.Entity<Stats>()
				.Property(e => e.Speed)
				.HasConversion(
					stat => stat.BaseValue,
					stat => new Stat(nameof(Stats.Speed), stat));

			base.OnModelCreating(modelBuilder);
		}
	}
}
