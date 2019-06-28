using System;

namespace YourChoice.Common.Exceptions
{
    public class YourChoiceException : Exception
    {
        public string Code { get; set; }

        public YourChoiceException()
        {
            
        }

        public YourChoiceException(string code)
        {
            Code = code;
        }

        public YourChoiceException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
            
        }

        public YourChoiceException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
            
        }

        public YourChoiceException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}