using System;
using System.Collections.Generic;

namespace GlobalX.Services.Impl
{
    public class NamesListProcessor : INamesListProcessor
    {
        public NamesListProcessor(List<string> inputNamesList)
        {
            if (inputNamesList == null || inputNamesList.Count == 0)
                throw new ArgumentException("Input name list should have at-least one value");
            _inputNamesList = inputNamesList;
            _validationErrors = new List<string>();
            _validNamesList = new List<string>();
            _validator = new NamesValidator();
            ProcessNamesList();
        }

        private void ProcessNamesList()
        {
            foreach (var namesRow in _inputNamesList)
            {
                if (_validator.IsNameListValid(namesRow))
                {
                    _validNamesList.Add(namesRow);
                }
                else
                {
                    _validationErrors.Add(_validator.GetValidationErrors(namesRow));
                }
            }
        }

        public List<string> GetValidNamesList()
        {
            return _validNamesList;
        }

        public List<string> GetValidationErrors()
        {
            return _validationErrors;
        }

        private readonly List<string> _inputNamesList;
        private readonly List<string> _validationErrors;
        private readonly List<string> _validNamesList;
        private readonly INamesValidator _validator;
    }
}