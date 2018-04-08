using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbRoles : EntityElem<Role>
    {
        public dbRoles(DbContext context, DbSet<Role> data) : base(context, data)
        {

        }

        

        public override IEnumerable<Role> Get
        {
            get
            {
                return Data;
            }
        }
    }
}