using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;    //+
using GF.Mvc01.Controllers; //+
using System.Web.Mvc;   //+

namespace GF.Mvc01.Facts.Controllers
{
    class HomeControllerFacts
    {
        public class TheIndexAction
        {
            //must add ref to System.Web.MVC4
            [Fact]
            public void ShouldReturnViewResult()
            {
                //able to check by dont need to run
                var c = new HomeController();
                var result = c.Index();
                Assert.IsType<ViewResult>(result);  //check that result is ViewResult
            }
        }
    }
}
