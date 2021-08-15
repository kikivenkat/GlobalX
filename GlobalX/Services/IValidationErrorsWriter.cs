using System.Collections.Generic;

namespace GlobalX.Services
{
    public interface IValidationErrorsWriter
    {
        void WriteValidationErrors(List<string> errors);
    }
}