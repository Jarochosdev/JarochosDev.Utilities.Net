using System;
using System.Collections.Generic;
using JarochosDev.Utilities.Net.NetStandard.Common.DependencyInjection;
using JarochosDev.Utilities.Net.NetStandard.Common.Processes;
using Microsoft.Extensions.DependencyInjection;

namespace JarochosDev.Utilities.Net.NetStandard.Common.Services
{
    public abstract class AbstractService : IStartableProcess, IFinalizerProcess
    {
        private bool _isStarted;
        private IServiceProvider _serviceProvider;
        private readonly List<IServiceModule> _serviceModules;
        internal IServiceProviderBuilder ServiceProviderBuilder { get; }
        public IReadOnlyCollection<IServiceModule> ServiceModules => _serviceModules.AsReadOnly();
        protected AbstractService(IEnumerable<IServiceModule> serviceModules) : this(serviceModules, new ServiceProviderBuilder(new ServiceCollection())) { }

        private AbstractService(IEnumerable<IServiceModule> serviceModules, IServiceProviderBuilder serviceProviderBuilder)
        {
            _serviceModules = new List<IServiceModule>();
            if (serviceModules != null)
            {
                _serviceModules.AddRange(serviceModules);
            }
            ServiceProviderBuilder = serviceProviderBuilder;
        }

        public IFinalizerProcess Start()
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

            return this;
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