using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GF.Mvc01.Models;

namespace GF.Mvc01.DataAccess
{
    public interface IPersonRepo
    {
        List<Person> GetAllPeople();
        int Add(Person p);
        Person GetById(int id);
        void Update(Person p);
        void Delete(int id);
    }
}