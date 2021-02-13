using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message, List<string> errors) : base(success, message, errors) => Data = data;

        public DataResult(T data, bool success, string message) : base(success, message) => Data = data;

        public DataResult(T data, bool success) : base(success) => Data = data;

        public T Data { get; }
    }
}