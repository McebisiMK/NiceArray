using NiceArray_Library.IValidators;
using NiceArray_Library.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiceArray_Library
{
    public class NiceArray
    {
        private IValidator _validator;

        public NiceArray () : this ( new Validator () )
        {
        }

        public NiceArray ( IValidator validator )
        {
            _validator = validator;
        }

        public bool IsNice ( List<string> list )
        {
            if ( list.Count > 0 )
            {
                list = _validator.Validate ( list );

                return list
                        .All ( number => list.Contains ( ( int.Parse ( number ) - 1 ).ToString () ) ||
                                          list.Contains ( ( int.Parse ( number ) + 1 ).ToString () ) );
            }
            return false;
        }
    }
}
