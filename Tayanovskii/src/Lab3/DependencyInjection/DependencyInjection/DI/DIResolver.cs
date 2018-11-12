using System;
using System.Collections.Generic;

namespace DependencyInjection.DI
{
    public class DIResolver
    {
        private readonly DIContainer diContainer;

        public DIResolver(DIContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public T Get<T>()
        {
            return (T) Get(typeof(T));
        }

        public object Get(Type contract)
        {
            if (diContainer.TypeInstances.ContainsKey(contract)) return diContainer.TypeInstances[contract];
            var implementation = diContainer.Types[contract];
            var constructor = implementation.GetConstructors()[0];
            var constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0) return Activator.CreateInstance(implementation);
            var parameters = new List<object>(constructorParameters.Length);
            foreach (var parameterInfo in constructorParameters) parameters.Add(Get(parameterInfo.ParameterType));
            return constructor.Invoke(parameters.ToArray());
        }
    }
}