using System;
using System.Collections.Generic;
using JarochosDev.Utilities.Net.NetStandard.ConsoleApp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.ConsoleApp
{
    public abstract class AbstractConsoleService : IConsoleService
    {
        private bool _isStarted;
        private IServiceProvider _serviceProvider;
        private readonly List<IServiceModule> _serviceModules;
        internal IServiceProviderBuilder ServiceProviderBuilder { get; }
        public IReadOnlyCollection<IServiceModule> ServiceModules => _serviceModules.AsReadOnly();
        protected AbstractConsoleService(IEnumerable<IServiceModule> serviceModules) : this(serviceModules, new ServiceProviderBuilder(new ServiceCollection())) { }

        private AbstractConsoleService(IEnumerable<IServiceModule> serviceModules, IServiceProviderBuilder serviceProviderBuilder)
        {
            _serviceModules = new List<IServiceModule>();
            if (serviceModules != null)
            {
                _serviceModules.AddRange(serviceModules);
            }
            ServiceProviderBuilder = serviceProviderBuilder;
        }

        public void Start()
        {
            if (!_isStarted)
            {

                _isStarted = true;

                try
                {
                    foreach (var serviceModule in ServiceModules)
                    {
                        ServiceProviderBuilder.AddServiceModule(serviceModule);
                    }

                    _serviceProvider = ServiceProviderBuilder.Build();

                    StartService(_serviceProvider);
                }
                catch (Exception error)
                {
                    _isStarted = false;
                    throw error;
                }
            }
        }

        protected abstract void StartService(IServiceProvider dependencyInjectionContainer);

        public void Stop()
        {
            if (_isStarted)
            {
                StopService(_serviceProvider);
            }
        }

        protected abstract void StopService(IServiceProvider dependencyInjectionContainer);
    }
}