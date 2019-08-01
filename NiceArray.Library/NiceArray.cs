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

        public NiceArray() : this(new Validator())
        {
        }

        public NiceArray(IValidator validator)
        {
            _validator = validator;
        }

        public bool IsNice(IEnumerable<string> list)
        {
            if (list.Any())
            {
                list = _validator.Validate(list);

                return list
                        .All(number => list.Contains(Predecessor(number)) ||
                                          list.Contains(Successor(number))
                        );
            }
            return false;
        }

        private string Predecessor(string number)
        {
            var predecessor = int.Parse(number) - 1;
            
            return predecessor.ToString();
        }

        private string Successor(string number)
        {
            int successor = int.Parse(number) + 1;

            return successor.ToString();
        }
    }
}
