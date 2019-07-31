using FluentAssertions;
using NiceArray_Library;
using NiceArray_Library.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiceArray_Specs
{
    [TestFixture]
    class NiceArrayTests
    {
        [Test]
        public void IsNice_Given_An_Empty_List_Should_Return_False ()
        {
            //-------------------------Arrange------------------------
            var list = new List<string> ();
            var niceList = CreateNiceList ();

            //-------------------------Act----------------------------
            var actual = niceList.IsNice ( list );

            //-------------------------Assert-------------------------
            actual.Should ().BeFalse ();
        }


        [TestCase ( new object [] { "1" } )]
        [TestCase ( new object [] { "10" } )]
        [TestCase ( new object [] { "100" } )]
        public void IsNice_Given_List_With_One_Number_Should_Return_False ( object [] array )
        {
            //-------------------------Arrange------------------------
            var list = array.Select ( item => item.ToString () ).ToList ();
            var niceList = CreateNiceList ();

            //-------------------------Act----------------------------
            var actual = niceList.IsNice ( list );

            //-------------------------Assert-------------------------
            actual.Should ().BeFalse ();
        }

        [TestCase ( new object [] { "1" , "2" } )]
        [TestCase ( new object [] { "10" , "23" , "24" , "9" } )]
        [TestCase ( new object [] { "100" , "34" , "36" , "101" , "35" } )]
        public void IsNice_Given_List_With_All_Numbers_Having_Either_Predesessor_And_Successor_Should_Return_True ( object [] array )
        {
            //-------------------------Arrange------------------------
            var list = array.Select ( item => item.ToString () ).ToList ();
            var niceList = CreateNiceList ();

            //-------------------------Act----------------------------
            var actual = niceList.IsNice ( list );

            //-------------------------Assert-------------------------
            actual.Should ().BeTrue ();
        }

        [TestCase ( new object [] { "1" , "3" } )]
        [TestCase ( new object [] { "10" , "23" , "24" } )]
        [TestCase ( new object [] { "100" , "34" , "36" , "101" } )]
        public void IsNice_Given_List_With_One_Or_More_Numbers_With_Both_No_Predesessor_And_Successor_Should_Return_False ( object [] array )
        {
            //-------------------------Arrange------------------------
            var list = array.Select ( item => item.ToString () ).ToList ();
            var niceList = CreateNiceList ();

            //-------------------------Act----------------------------
            var actual = niceList.IsNice ( list );

            //-------------------------Assert-------------------------
            actual.Should ().BeFalse ();
        }

        [TestCase ( new object [] { "1" , "3-" } , "3-" )]
        [TestCase ( new object [] { "10" , "23." , "24" , "11z" } , "23., 11z" )]
        [TestCase ( new object [] { "100" , "34%" , "36" , "101#" , "35*" } , "34%, 101#, 35*" )]
        public void IsNice_Given_List_With_One_Or_More_Numbers_Cannot_Be_Converted_To_Number_Should_Should_Throw_Exception_With_List_Of_Those_Numbers ( object [] array , string invalids )
        {
            //-------------------------Arrange------------------------
            var list = array.Select ( item => item.ToString () ).ToList ();
            var niceList = CreateNiceList ();

            //-------------------------Act----------------------------
            var exception = Assert.Throws<InvalidNumberException> ( () => niceList.IsNice ( list ) );

            //-------------------------Assert-------------------------
            exception.Message.Should ().Be ( $" '{invalids}' can not be converted to numbers" );
        }

        private static NiceArray CreateNiceList ()
        {
            return new NiceArray ();
        }
    }
}
