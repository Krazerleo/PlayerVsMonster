using System;
using System.Collections.Generic;

namespace PlayerVsMonster.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service)
        {
            _services[typeof(T)] = service!;
        }

        public static void Reset()
        {
            _services.Clear();
        }

        public static T Resolve<T>()
        {
            return (T) _services[typeof(T)];
        }
    }
}