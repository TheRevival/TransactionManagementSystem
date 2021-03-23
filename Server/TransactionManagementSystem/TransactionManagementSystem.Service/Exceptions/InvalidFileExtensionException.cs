using System;

namespace TransactionManagementSystem.Service.Exceptions
{
    public class InvalidFileExtensionException : ArgumentException
    {
        public InvalidFileExtensionException() { }
        
        public InvalidFileExtensionException(string message)
            : base(message)
        { }
        
        public InvalidFileExtensionException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}