using System;

namespace Neoris.Ionleap.CrossCutting.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}