using System;
using System.Collections.Generic;
using System.Text;

namespace NiceArray_Library.IValidators
{
    public interface IValidator
    {
        List<string> Validate ( List<string> list );
    }
}
