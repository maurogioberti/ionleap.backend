using System;

namespace Neoris.Ionleap.CrossCutting.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }
    }
}