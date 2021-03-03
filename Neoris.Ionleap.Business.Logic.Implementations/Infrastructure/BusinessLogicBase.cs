using System;
using System.Reflection;

namespace Neoris.Ionleap.Business.Logic.Implementations.Infrastructure
{
    public class BusinessLogicBase
    {
        protected void HandleException(Exception exception)
        {
            CrossCutting.Logging.Logger.Write(exception, Assembly.GetCallingAssembly().GetName().Name);
        }
    }
}