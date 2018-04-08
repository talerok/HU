using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class MainPage
    {
        public Person Person { get; set;}
        public IEnumerable<Services.Service> Services { get; set; }
    }
}