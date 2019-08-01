using System;
using System.Collections.Generic;
using System.Text;

namespace NiceArray_Library.IValidators
{
    public interface IValidator
    {
        IEnumerable<string> Validate(IEnumerable<string> list);
    }
}
