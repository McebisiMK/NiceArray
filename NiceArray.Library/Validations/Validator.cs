using NiceArray_Library.Exceptions;
using NiceArray_Library.IValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiceArray_Library.Validations
{
    public class Validator : IValidator
    {
        public List<string> Validate ( List<string> list )
        {
            var invalids = GetInvalids ( list );
            if ( invalids.Count > 0 )
            {
                throw new InvalidNumberException ( invalids );
            }
            return list;
        }

        private List<string> GetInvalids ( List<string> list )
        {
            var invalids = new List<string> ();
            foreach ( var item in list )
            {
                var valid = int.TryParse ( item , out int n );
                if ( !valid )
                {
                    invalids.Add ( item );
                }
            }

            return invalids;
        }
    }
}
