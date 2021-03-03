using System;
using System.Reflection;

namespace Neoris.Ionleap.Services.Implementations.Infrastructure
{
    public class ServiceBase
    {
        protected void HandleException(Exception exception)
        {
            CrossCutting.Logging.Logger.Write(exception, Assembly.GetCallingAssembly().GetName().Name);
        }
    }
}