using System;

namespace CapitalPlacement;
public class HttpResponseException : Exception
{
    public int StatusCode { get; }
    public object? Value { get; }

    public HttpResponseException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        Value = new { Message = message };
    }
}

