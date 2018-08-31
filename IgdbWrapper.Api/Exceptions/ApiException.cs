using System;

namespace IgdbWrapper.Api.Exceptions
{
    /// <summary>
    /// Exception class used when the IGDB API throws a non 200 response.
    /// </summary>
    /// <inheritdoc cref="Exception"/>
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}