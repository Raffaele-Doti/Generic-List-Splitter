using ListSplitter.Helpers;
using ListSplitter.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ListSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            //obtaining service provider
            var serviceProvider = GetServiceProvider();
            //creating a scope for the application
            using (var scope = serviceProvider.CreateScope())
            {
                //class which contains entry point method.
                scope.ServiceProvider.GetRequiredService<Startup>().Start();
            }
            //disposing service container
            DisposeServiceProvider(serviceProvider);
        }
        #region Methods

        /// <summary>
        /// Method used to register type into service container and to build it.
        /// </summary>
        private static ServiceProvider GetServiceProvider()
        {
            //instanciate service collection.
            var services = new ServiceCollection();
            //register types .
            services.AddSingleton<Startup>()
            .AddSingleton<IListSplitterHelper, ListSplitterHelper>();
            //building service container.
            return services.BuildServiceProvider(true);
        }

        /// <summary>
        /// Used to dispose service container.
        /// </summary>
        /// <param name="serviceProvider"></param>
        private static void DisposeServiceProvider(ServiceProvider serviceProvider)
        {
            //if null nothing to dispose
            if (serviceProvider == null)
            {
                return;
            }
            //disposing service container
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }

        #endregion
    }
}
