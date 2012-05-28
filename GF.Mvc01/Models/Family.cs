using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GF.Mvc01.Models
{
    public class Family
    {
        public string Name { get; set; }
        public Person Husband { get; set; }
        public Person Wife { get; set; }
    }
}