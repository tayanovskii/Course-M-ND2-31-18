using System;
using System.Collections.Generic;
using System.Reflection;

namespace DependencyInjection.DI
{
    public  class DIResolver
    {
        private readonly DIContainer diContainer;

        public DIResolver(DIContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public  T Get<T>()
        {
            return (T)Get(typeof(T));
        }
        public  object Get(Type contract)
        {
            if (diContainer.TypeInstances.ContainsKey(contract))
            {
                return diContainer.TypeInstances[contract];
            }
            Type implementation = diContainer.Types[contract];
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation);
            }
            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                parameters.Add(Get(parameterInfo.ParameterType));
            }
            return constructor.Invoke(parameters.ToArray());
        }
    }
}