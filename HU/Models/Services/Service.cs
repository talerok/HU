using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HU.Models.Services
{
    public class Service : Indf.Indf
    {
        [DisplayName("Информация о услуге")]
        public ServiceInfo Info { get; set; }
        [DisplayName("Квартира")]
        public Flat Flat { get; set; }
        [DisplayName("Дата начисления")]
        public DateTime Date { get; set; }
        [DisplayName("Кол-во")]
        public decimal Count { get; set; }
    }
}