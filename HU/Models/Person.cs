using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HU.Models
{
    public class Person : Indf.Indf
    {
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("ФИО")]
        public string Name { get; set; }
        [DisplayName("Паспорт (серия и номер)")]
        public string Passport { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Должность")]
        public Role Role { get; set;}

        public List<Possession> Possessions { get; set; }
    }
}