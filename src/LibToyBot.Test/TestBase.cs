using LibToyBot.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace LibToyBot.Test
{
    /// <summary>A base class for unit tests that implements a service provider for Dependency Injection resolution of the system under test</summary>
    public abstract class TestBase
    {
        protected ServiceProvider serviceProvider;
        protected readonly ServiceCollection serviceCollection;

        protected TestBase()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddRobot();
        }

        /// <summary>
        /// Builds the services collection
        /// </summary>
        internal void BuildServices()
        {
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Substitutes the generic type and updates the service collection with the mocked implementation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T</returns>
        public T SubstituteFor<T>() where T : class
        {
            var mock = Substitute.For<T>();
            serviceCollection.AddScoped<T>(provider => mock);
            return mock;
        }
    }
}
