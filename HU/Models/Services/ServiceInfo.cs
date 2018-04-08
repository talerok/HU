using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HU.Models.Services
{
    public class ServiceInfo : Indf.Indf
    {
        [DisplayName("Тип услуги")]
        public string Name { get; set; }
        [DisplayName("Начало действия")]
        public DateTime StartTime { get; set; }
        [DisplayName("Конец действия")]
        public DateTime EndTime { get; set; }
        [DisplayName("Цена за единицу")]
        public decimal Price { get; set; }
        [Required, DisplayName("Тип расчета")]
        public PayementType paymentType { get; set; }

        public List<Service> Services { get; set; }
    }
}