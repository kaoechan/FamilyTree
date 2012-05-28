using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit; //+
using GF.Mvc01.Models; //+

namespace GF.Mvc01.Facts.Models
{
    public class PersonFacts
    {

        public class TheGenderProperty
        {
            private Person p;
            public TheGenderProperty ()
	        {
                p = new Person();
	        }

            [Fact]
            public void CanAcceptsMale()
            {
                p.Gender = "M";
                Assert.Equal("m", p.Gender);
            }

            [Fact]
            public void CanAcceptsFemale()
            {
                p.Gender = "F";
                Assert.Equal("f", p.Gender);
            }

            [Fact]
            public void CantAcceptsOtherGenders()
            {
                Assert.Throws<Exception>(() =>
                {
                    p.Gender = "X";
                });
            }

        }

        [Fact]
        public void BirthYearIsNotInTheFuture()
        {
            //arrange
            Person p = new Person();
            
            //assert
            Assert.Throws<Exception>(() => {
                //action (assume this year is 2012)
                //p.BirthYear = 3000;
                p.BirthYear = DateTime.Now.Year + 1;
            });

        }

        [Fact]
        public void BirthYearInPastOrPresentIsOkay()
        {
            //arrange
            Person p = new Person();
            int thisYear = DateTime.Now.Year;
            //assert
            Assert.DoesNotThrow(() =>
            {
                //action (assume this year is 2012)
                //p.BirthYear = 3000;
                p.BirthYear = thisYear;
            });
            //check assert to check actual data (expect, acture)
            Assert.Equal(thisYear, p.BirthYear);
        }

        /// <summary>
        /// :The GetAge Method Test
        /// </summary>
        public class TheGetAgeMethod
        {
            [Fact]
            public void ShouldReturnValidAge()
            {
                Person p = new Person();
                int thisYear = DateTime.Now.Year;
                p.BirthYear = thisYear - 12;
                int age = 0;
                Assert.DoesNotThrow(() =>
                {
                    age = p.GetAge();
                   
                });
                Assert.True(age >= 0);
            }//End ShouldReturnValidAge
        }
        //////////////////////////////////////////////////////

        /// <summary>
        /// :The Marry Method Test
        /// </summary>
        public class TheMarryMethod
        {
            
            [Fact]
            public void ThrowExceptionIfAgeLessThan20Years()
            {
                Person p1 = new Person();
                Person p2 = new Person();
                int thisYear = DateTime.Now.Year;
                p1.BirthYear = thisYear;    //0
                p2.BirthYear = thisYear;    //0

                // Generics
                Assert.Throws<Exception>(() =>
                {
                    p1.Marry(p2);
                });
            }

            [Fact]
            public void MaleCannotMarryToMale()
            {

                Person p1 = new Person();
                Person p2 = new Person();
                p1.Gender = "M";
                p2.Gender = "M";

                Assert.Throws<Exception>(() =>
                {
                    p1.Marry(p2);
                });
            }

            [Fact]
            public void FemaleCannotMarryToFemale()
            {

                Person p1 = new Person();
                Person p2 = new Person();
                p1.Gender = "F";
                p2.Gender = "F";

                Assert.Throws<Exception>(() =>
                {
                    p1.Marry(p2);
                });
            }

            [Fact]
            public void MaleCanMarryToFemaleIfAgeGreaterThan20()
            {

                Person p1 = new Person();
                Person p2 = new Person();

                int thisYear = DateTime.Now.Year;
                p1.BirthYear = thisYear - 30;     //20
                p2.BirthYear = thisYear - 30;     //20

                p1.Gender = "M";
                p2.Gender = "F";

                Assert.DoesNotThrow(() =>
                {
                    p1.Marry(p2);
                });
            }

            [Fact]
            public void ShouldReturnFamily()
            {

                Person p1 = new Person();
                Person p2 = new Person();

                p1.Gender = "M";
                p2.Gender = "F";

                Family f = p1.Marry(p2);

                Assert.NotNull(f);

            }

            [Fact]
            public void MarriedPersonHasSameFamily()
            {

                Person p1 = new Person() { Gender = "M" };
                Person p2 = new Person() { Gender = "F" };

                p1.Marry(p2);

                Assert.NotNull(p1.Family);
                Assert.NotNull(p2.Family);
                Assert.Same(p1.Family, p2.Family);

            }

            [Fact]
            public void FamilyHasHusbandAndWife()
            {

                Person p1 = new Person() { Gender = "M" };
                Person p2 = new Person() { Gender = "F" };

                Family f = p1.Marry(p2);
                Assert.Same(f.Husband, p1);
                Assert.Same(f.Wife, p2);
            }
        }
        //////////////////////////////////////////////////////
    }
}
