﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GF.Mvc01.Models
{
    public class Person
    {
        public int Id { get; set; }
        // auto-implemented property
        public string Name { get; set; }
        public Family Family { get; set; }
        //standard property Gender
        private string _Gender;
        public string Gender {
            get
            {
                return _Gender;
            }
            set
            {

                if (value.ToLower().Equals("f") || value.ToLower().Equals("m"))
                {
                    _Gender = value.ToLower();
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        
        //standard property BirthYear
        private int _BirthYear;
        public int BirthYear {
            get
            {
                return _BirthYear;
            }
            set
            {
                //value is input  -> check that value is less or equal to today
                if (value <= DateTime.Now.Year)
                {
                    _BirthYear = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////
        public int GetAge()
        {
            if (DateTime.Now.Year - _BirthYear < 0)
            {
                throw new Exception();
            }
            else
            {
                return DateTime.Now.Year - _BirthYear;
            }
        }

        public Family Marry(Person spouse)
        {
            if (this.GetAge() < 20 || spouse.GetAge() < 20)
            {
                throw new Exception();
            }
            else if (this.Gender == spouse.Gender)
            {
                throw new Exception();
            }
            else
            {
                Family f = new Family();
                if (this.Gender.ToLower().Equals("m"))
                {
                    f.Name = this.Name + spouse.Name;
                    f.Husband = this;
                    f.Wife = spouse;
                }
                else
                {
                    f.Name = spouse.Name + this.Name;
                    f.Husband = spouse;
                    f.Wife = this;
                }
                this.Family = f;
                spouse.Family = f;
                return f;
            }


        }
    }
}