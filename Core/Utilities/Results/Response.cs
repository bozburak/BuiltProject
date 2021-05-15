using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public IEnumerable<string> Errors { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode };
        }

        public static Response<T> Fail(string errorMessage, int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string>() { errorMessage },
                StatusCode = statusCode,
            };
        }

        public static Response<T> Fail(IEnumerable<string> errorMessage, int statusCode)
        {
            return new Response<T>
            {
                Errors = errorMessage,
                StatusCode = statusCode,
            };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode };
        }
    }
}
