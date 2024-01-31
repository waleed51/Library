using Library.Core.Interfaces.Common;
using System.Text.RegularExpressions;

namespace Library.Core.Common.Services
{
    public class ValidationService : IValidationService
    {
        public bool IsValidSearchText(string input)
        {
            return input.Length <= 100;
        }

        public string SanitizeSearchText(string input)
        {
            return Regex.Replace(input, @"[^\w\s]", string.Empty);
        }
    }
}
