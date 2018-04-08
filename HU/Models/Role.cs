using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class Role : Indf.Indf
    {
        [DisplayName("Уровень доступа")]
        public byte Level { get; set; }
        [DisplayName("Название должности")]
        public string Name { get; set; }

        public List<Person> People { get; set; }
    }
}