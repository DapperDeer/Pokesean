using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WpfLibrary1
{
	public class PokemonContextFactory : IDesignTimeDbContextFactory<PokemonDBContext>
	{
		public PokemonDBContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder();
			optionsBuilder.UseSqlite(@$"Data Source={Environment.CurrentDirectory}\pokemon12.db");

			return new PokemonDBContext(optionsBuilder.Options);
		}
	}

	public static class ContextFactoryExtensions
	{ 
		public static PokemonDBContext CreateDbContext(this IDesignTimeDbContextFactory<PokemonDBContext> contextFactory)
		{
			return contextFactory.CreateDbContext(Array.Empty<string>());
		}
	}
}
