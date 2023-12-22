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

			base.OnModelCreating(modelBuilder);
		}
	}
}
