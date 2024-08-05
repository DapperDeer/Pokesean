using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WpfLibrary1
{
	public class PokemonContextFactory : IDesignTimeDbContextFactory<PokemonDBContext>
	{
		public PokemonDBContext CreateDbContext(string[] args)
		{
			string fileName = $"{Environment.CurrentDirectory}\\pokemon.db";
			var optionsBuilder = new DbContextOptionsBuilder();
			optionsBuilder.UseSqlite(@$"Data Source={fileName}");

			return new PokemonDBContext(optionsBuilder.Options);
		}
	}

	public static class ContextFactoryExtensions
	{ 
		public static PokemonDBContext CreateDbContext(this IDesignTimeDbContextFactory<PokemonDBContext> contextFactory) =>
			contextFactory.CreateDbContext(Array.Empty<string>());
	}
}
