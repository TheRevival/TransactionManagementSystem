using System;

namespace TransactionManagementSystem.Service.Exceptions
{
    public class TransactionDoesNotExistException : Exception
    {
        public TransactionDoesNotExistException() { }
        
        public TransactionDoesNotExistException(string message)
            : base(message)
        { }
        
        public TransactionDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}