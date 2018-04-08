using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class Flat : Indf.Indf
    {
        [DisplayName("Адрес")]
        public string Adress { get; set; }
        public List<Possession> Possessions { get; set; }

        public List<Services.Service> Services { get; set; }
    }
}