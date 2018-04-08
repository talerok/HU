using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HU.Logic.Db
{
    public class EntityElem<T> : Logic.Interfaces.IDBElem<T> where T: Models.Indf.Indf
    {
        public virtual IEnumerable<T> Get => throw new NotImplementedException();

        protected DbSet<T> Data;

        public void Add(T add)
        {
            Data.Add(add);
        }

        public void Dell(T del)
        {
            Data.Remove(del);
        }

        private DbContext Context;

        public void Edited(T edt)
        {
            var a = Data.FirstOrDefault(x => x.Id == edt.Id);
            if (a == null) return;
            if (a != edt) Context.Entry(a).State = EntityState.Detached;
    
            Context.Entry(edt).State = EntityState.Modified;
        }

        public EntityElem(DbContext context, DbSet<T> data)
        {
            Context = context;
            Data = data;
        }
    }
}