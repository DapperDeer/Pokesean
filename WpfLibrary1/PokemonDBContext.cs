using Microsoft.EntityFrameworkCore;

namespace WpfLibrary1
{
	public class PokemonDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
	{
		public DbSet<Pokemon> Pokemon { get; set; }

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

			modelBuilder.Entity<Pokemon>()
				.Property(e => e.ImageSource)
				.HasConversion(
					src => src!.ToString(),
					src => new System.Windows.Media.Imaging.BitmapImage(new Uri(src)));

			base.OnModelCreating(modelBuilder);
		}
	}
}
