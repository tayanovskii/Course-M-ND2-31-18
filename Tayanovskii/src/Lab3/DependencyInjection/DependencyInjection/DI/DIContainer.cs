using System;
using System.Collections.Generic;

namespace DependencyInjection.DI
{
    public class DIContainer
    {
        public IDictionary<Type, Type> Types { get; }
        public IDictionary<Type, object> TypeInstances { get; }

        public DIContainer()
        {
            Types = new Dictionary<Type, Type>();
            TypeInstances = new Dictionary<Type, object>();
        }

        //static DIContainer(IDictionary<Type, Type> types, IDictionary<Type, object> typeInstances)
       // {
       //     types = new Dictionary<Type, Type>();
       //     typeInstances = new Dictionary<Type, object>();
       // }

        //private readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();
        //private readonly IDictionary<Type, object> typeInstances = new Dictionary<Type, object>();

        public void Register<TContract, TImplementation>()
        {
            Types[typeof(TContract)] = typeof(TImplementation);
        }
        public void Register<TContract, TImplementation>(TImplementation instance)
        {
            TypeInstances[typeof(TContract)] = instance;
        }
   
    }
}