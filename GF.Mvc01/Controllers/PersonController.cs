using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GF.Mvc01.DataAccess;
using GF.Mvc01.Models;
namespace GF.Mvc01.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/
        private IPersonRepo repo;
        //ไม่มีการรับ call default constructor
        public PersonController() : this(new PersonRepo())
        {
            //
        }
        public PersonController(IPersonRepo repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            var people = repo.GetAllPeople();
            //var people = new List<Person>();
            return View(people);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)    //Input will go in here, model state
        {
            if (ModelState.IsValid)
            {
                repo.Add(p);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Person p = repo.GetById(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            if (ModelState.IsValid)
            {
                repo.Update(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            Person p = repo.GetById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        
        [ActionName("Delete")] //because it is override
        [HttpPost]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Person p = repo.GetById(id);
            return View(p);
        }
    }
}
