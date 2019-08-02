using System;
using System.Collections.Generic;
using System.Text;

namespace NiceArray_Library.IValidators
{
    public interface IValidator
    {
        void Validate(IEnumerable<string> list);
    }
}
