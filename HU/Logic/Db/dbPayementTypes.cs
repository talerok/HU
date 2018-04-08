using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbPayementTypes : EntityElem<PayementType> 
    {
        public dbPayementTypes(DbContext context, DbSet<PayementType> data) : base(context, data)
        {

        }

        public override IEnumerable<PayementType> Get
        {
            get
            {
                return Data;
            }
        }
    }
}