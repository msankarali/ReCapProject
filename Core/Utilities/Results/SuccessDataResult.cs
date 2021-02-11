using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public SuccessDataResult(T data, string message, List<string> errors) : base(data, true, message, errors) { }
        public SuccessDataResult(T data, string message) : base(data, true, message) { }
        public SuccessDataResult(T data) : base(data, true) { }
    }
}
