using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;
using System.Data.Entity;

namespace HU.Logic.Db
{
    public class dbFlats : EntityElem<Flat>
    {
        public dbFlats(DbContext context, DbSet<Flat> data) : base(context, data)
        {

        }

        public override IEnumerable<Flat> Get
        {
            get
            {
                return Data;
            }
        }
    }
}