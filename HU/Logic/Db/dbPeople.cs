using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HU.Logic.Db
{
    public class dbPeople : EntityElem<Person> 
    {
        public dbPeople(DbContext context, DbSet<Person> data) : base(context, data)
        {

        }

        public override IEnumerable<Person> Get
        {
            get
            {          
                return Data.Include(x => x.Role);
            }
        }
        
    }
}