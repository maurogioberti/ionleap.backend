using System;

namespace Neoris.Ionleap.CrossCutting.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}