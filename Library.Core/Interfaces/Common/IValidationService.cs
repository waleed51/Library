namespace Library.Core.Interfaces.Common
{
    public interface IValidationService
    {
        string SanitizeSearchText(string input);
        bool IsValidSearchText(string input);
    }
}
