using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbPossessions : EntityElem<Possession>
    {
        public dbPossessions(DbContext context, DbSet<Possession> data) : base(context, data)
        {

        }

        public override IEnumerable<Possession> Get
        {
            get
            {
                return Data.Include(x => x.Flat).Include(x => x.Owner);
            }
        }
    }
}