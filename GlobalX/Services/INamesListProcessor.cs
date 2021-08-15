using System.Collections.Generic;

namespace GlobalX.Services
{
    public interface INamesListProcessor
    {
        List<string> GetValidNamesList();
        List<string> GetValidationErrors();
    }
}