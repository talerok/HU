using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HU.Models;
using HU.Models.Services;
using HU.Logic.Interfaces;

namespace HU.Logic
{
    public class EntityContext : DbContext, Interfaces.IContext
    {
        public Interfaces.IDBElem<Flat> Flats { get; private set; }
        public Interfaces.IDBElem<Person> People { get; private set; }
        public Interfaces.IDBElem<Possession> Possession { get; private set; }

        public Interfaces.IDBElem<PayementType> PaymentTypes { get; private set; }
        public Interfaces.IDBElem<Service> Services { get; private set; }
        public Interfaces.IDBElem<ServiceInfo> ServicesInfos { get; private set; }
        public Interfaces.IDBElem<Role> RoleInfos { get; private set; }

        public IDBElem<PayementFact> PayementFacts  { get; private set;}
        //-------------------------------------------------------------------
        public DbSet<Flat> FlatSet { get; set; }

        public DbSet<Person> PeopleSet { get; set; }

        public DbSet<Possession> PossessionsSet { get; set; }

        public DbSet<PayementType> PayementTypesSet { get; set; }

        public DbSet<Service> ServicesSet { get; set; }

        public DbSet<ServiceInfo> ServicesInfosSet { get; set; }

        public DbSet<Role> RolesSet { get; set; }

        public DbSet<PayementFact> PayementFactsSet { get; set; }

        //--------------------------------------------------------------------
        public void Save()
        {
            SaveChanges();
        }

        public EntityContext(string dbName) : base(dbName)
        {

            //-----------------------------
            RoleInfos = new Db.dbRoles(this,RolesSet);
            PaymentTypes = new Db.dbPayementTypes(this,PayementTypesSet);
            People = new Db.dbPeople(this, PeopleSet);
            Flats = new Db.dbFlats(this, FlatSet);
            Possession = new Db.dbPossessions(this, PossessionsSet);

            ServicesInfos = new Db.dbServiceInfos(this, ServicesInfosSet);
            Services = new Db.dbServices(this, ServicesSet);
            PayementFacts = new Db.dbPayementFacts(this, PayementFactsSet);
           
        }
        
        
    }
}