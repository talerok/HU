using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class Possession : Indf.Indf
    {
        [DisplayName("Вступление в силу")]
        public DateTime Start { get; set; }
        [DisplayName("Дата расторжения")]
        public DateTime End { get; set; }
        [DisplayName("Квартира")]
        public Flat Flat { get; set; }
        [DisplayName("Владелец")]
        public Person Owner { get; set; }
        [DisplayName("Площадь")]
        public decimal Size { get; set; }
    }
}