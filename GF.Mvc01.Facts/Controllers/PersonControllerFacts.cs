using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;    //+
using GF.Mvc01.Controllers; //+
using GF.Mvc01.Models; //+
using System.Web.Mvc;   //+
using Moq;
using GF.Mvc01.DataAccess;  //+
namespace GF.Mvc01.Facts.Controllers
{
    class PersonControllerFacts
    {
        public class TheIndexAction
        {
            [Fact]
            public void ShouldSendListOfPersonToView()
            {
                var repo = new Mock<IPersonRepo>();
                
                repo
                    .Setup(x => x.GetAllPeople())
                    .Returns(new List<Person>() {
                    new Person() {Id = 1, Name = "Mr.A", Gender = "M", BirthYear=1900}, 
                    new Person() {Id = 2, Name = "Ms.B", Gender = "F", BirthYear=1905}
                });

                var c = new PersonController(repo.Object);  //need to be object
                var result = c.Index() as ViewResult;

                
                Assert.IsType<List<Person>>(result.Model);
                Assert.NotNull(result.Model);
                Assert.Equal(2,((List<Person>)(result.Model)).Count);
                repo.Verify(x => x.GetAllPeople());
            }


        }
    }
}
