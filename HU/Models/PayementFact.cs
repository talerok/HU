using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class PayementFact : Indf.Indf
    {
        [DisplayName("На кого выставлен счет")]
        public Person Person { get; set; }
        [DisplayName("Услуга")]
        public Services.Service Service { get; set; }
        [DisplayName("Оплачено")]
        public bool Paid { get; set; }
    }
}