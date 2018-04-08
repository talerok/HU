using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HU.Models.Services
{
    public class PayementType : Indf.Indf
    {
        [DisplayName("Вид расчета")]
        public string Name { get; set; }
        [DisplayName("Индификатор вида расчета")]
        public short Type { get; set; }

        public List<ServiceInfo> ServicesInfos { get; set; }
    }
}