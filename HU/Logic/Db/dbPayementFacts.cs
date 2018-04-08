using HU.Models;
using HU.Models.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HU.Logic.Db
{
    public class dbPayementFacts : EntityElem<PayementFact>
    {
        public dbPayementFacts(DbContext context, DbSet<PayementFact> data) : base(context, data)
        {

        }

        public override IEnumerable<PayementFact> Get
        {
            get
            {
                return Data.Include(x => x.Person).Include(x => x.Service);
            }
        }
    }
}