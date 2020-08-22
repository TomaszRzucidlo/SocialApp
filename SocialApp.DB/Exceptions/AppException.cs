using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Exceptions
{
    public class AppException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public AppException(ErrorCode errorCode)
    :       this(errorCode, errorCode.Message)
        {
        }

        public AppException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        public AppException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
