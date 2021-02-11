using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, List<string> errors) : base(false, message, errors) { }
        public ErrorResult(string message) : base(false, message) { }
    }
}
