using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;

namespace HU.Logic.Interfaces
{
    public interface IContext
    {
        IDBElem<Flat> Flats { get; }
        IDBElem<Person> People { get; }
        IDBElem<Possession> Possession { get; }

        IDBElem<PayementType> PaymentTypes { get; }
        IDBElem<Service> Services { get; }
        IDBElem<ServiceInfo> ServicesInfos { get; }

        IDBElem<Role> RoleInfos { get; }

        IDBElem<PayementFact> PayementFacts { get; }

        void Save();

    }
}