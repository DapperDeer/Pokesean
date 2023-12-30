using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1
{
	public interface IViewModelFactory<T>
	{
		T CreateViewModel();
	}

	public class ViewModelFactory<T> : IViewModelFactory<T>
	{
		private readonly Func<T> _factory;

        public ViewModelFactory(Func<T> factory)
        {
			_factory = factory;
        }

        public T CreateViewModel()
		{
			return _factory();
		}
	}

	public static class ServiceExtensions
	{
		public static void AddViewModelFactory<T>(this IServiceCollection services)
			where T : class
		{
			services.AddTransient<T>();
			services.AddTransient<Func<T>>(x => () => x.GetService<T>()!);
			services.AddSingleton<IViewModelFactory<T>, ViewModelFactory<T>>();
		}
	}
}
