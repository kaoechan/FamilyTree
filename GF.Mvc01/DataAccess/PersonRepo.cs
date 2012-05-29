using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GF.Mvc01.Models;
using System.Diagnostics;

namespace GF.Mvc01.DataAccess
{
    public class PersonRepo : IPersonRepo
    {
        public List<Models.Person> GetAllPeople()
        {
            using (var db = new FamilyContext())
            {
                var q = from p in db.People
                        select p;

                return q.ToList();
            }
        }


        public int Add(Person p)
        {
            using (var db = new FamilyContext())
            {
                db.People.Add(p);
                db.SaveChanges();
                return p.Id;
            }
        }


        public Person GetById(int id)
        {
            using (var db = new FamilyContext())
            {
                return db.People.Find(id);
            }
        }

        public void Update(Person p)
        {
            using (var db = new FamilyContext())
            {
                var personFromDb = db.People.Find(p.Id);
                
                //if(!p.Equals(personFromDb))
               // {
                    //db.People.Attach(p);
                    //db.Entry(p).State = System.Data.EntityState.Modified;
                    personFromDb.Name = p.Name;
                    personFromDb.Gender = p.Gender;
                    personFromDb.BirthYear = p.BirthYear;
                //}
                

                //db.People.Attach(p);
                //db.Entry(p).State = System.Data.EntityState.Modified;
                int n = db.SaveChanges();
                Debug.Print("update={0} rows", n);
            }
        }

        public void Delete(int id)
        {
            using (var db = new FamilyContext())
            {
                Person p = new Person();
                p.Id = id;
                db.People.Attach(p);
                db.Entry(p).State = System.Data.EntityState.Deleted;
                int n = db.SaveChanges();
                Debug.Print("delete={0} rows",n);
            }
        }
    }
}