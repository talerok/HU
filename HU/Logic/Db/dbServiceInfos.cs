using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbServiceInfos : EntityElem<ServiceInfo> 
    {
        public dbServiceInfos(DbContext context, DbSet<ServiceInfo> data) : base(context, data)
        {

        }

        public override IEnumerable<ServiceInfo> Get
        {
            get
            {
                return Data.Include(x => x.paymentType);
            }
        }
    }
}