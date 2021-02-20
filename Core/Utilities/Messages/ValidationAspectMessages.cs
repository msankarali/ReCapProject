using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Messages
{
    public static class ValidationAspectMessages
    {
        public static string NotAValidClass(string fullName) => $"Bu bir doğrulama sınıfı değil. Details: {fullName}";
    }
}
