using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using BlogManager.Configuration;

namespace BlogManager.Services
{
    public static class ServiceRepository
    {
        private static IServiceFactory factory;

        static ServiceRepository()
        {
            factory = (IServiceFactory) Activator.CreateInstance(
                Type.GetType(Settings.Default.FactoryName));
        }

        public static IServiceFactory Factory
        {
            get { return factory; } 
        }
    }
}
