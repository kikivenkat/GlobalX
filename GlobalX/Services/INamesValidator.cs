namespace GlobalX.Services
{
    public interface INamesValidator
    {
        bool IsNameListValid(string nameList);
        string GetValidationErrors(string nameList);
    }
}