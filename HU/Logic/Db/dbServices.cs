using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbServices : EntityElem<Service>
    {
        public dbServices(DbContext context, DbSet<Service> data) : base(context, data)
        {

        }

        public override IEnumerable<Service> Get
        {
            get
            {
                return Data.Include(x => x.Flat).Include(x => x.Info).Include(x => x.Info.paymentType);
            }
        }
    }
}