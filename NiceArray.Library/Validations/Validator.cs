using NiceArray_Library.Exceptions;
using NiceArray_Library.IValidators;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace NiceArray_Library.Validations
{
    public class Validator : IValidator
    {
        public IEnumerable<string> Validate(IEnumerable<string> list)
        {
            var invalids = list.Where(number => IsInvalid(number)).ToList();

            return invalids.Any() ? throw new InvalidNumberException(invalids) : list; 
        }

        private bool IsInvalid(string number)
        {
            return !int.TryParse(number, out int n);
        }
    }
}
