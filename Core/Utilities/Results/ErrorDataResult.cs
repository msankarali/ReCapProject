using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data, string message, List<string> errors) : base(data, false, message, errors)
        {
        }
    }
}
