using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfLibrary1;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IServiceProvider _serviceProvider;

		/// <summary>
		/// Interaction logic for App.xaml
		/// </summary>
		public App()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<ITrainerCoordinator, TrainerCoordinator>();
			serviceCollection.AddSingleton<IPokemonCoordinator, PokemonCoordinator>();
			serviceCollection.AddSingleton<IPokeClient, PokeClient>();
			serviceCollection.AddViewModelFactory<TrainerVM>();
			serviceCollection.AddViewModelFactory<PokemonVM>();
			serviceCollection.AddSqliteDatabase();
			serviceCollection.AddSingleton<MainWindow>();
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = _serviceProvider.GetService<MainWindow>();
			mainWindow?.Show();
		}
	}

	internal static class DatabaseExtensions
	{ 
		internal static IServiceCollection AddSqliteDatabase(this IServiceCollection services)
		{
			services.AddDbContext<PokemonDBContext>();
			services.AddSingleton<IDesignTimeDbContextFactory<PokemonDBContext>, PokemonContextFactory>();
			return services;
		}
	}
}
