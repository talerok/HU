using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;

namespace HU.Logic
{
    public class ContextHelper
    {
        private Interfaces.IContext context;

        public ContextHelper(Interfaces.IContext cntx)
        {
            context = cntx;
        }

        public IEnumerable<Service> GetServicesByFlat(Flat flat)
        {
            return context.Services.Get.Where(x => x.Flat == flat);
        }

        public int GetFlatPeopleCount(Flat flat)
        {
            return context.Possession.Get.Where(x => x.Flat == flat).Select(x => x.Owner).Distinct().Count();
        }

        public decimal GetPersonFlatProportion(Person person, Flat flat)
        {
            var FlatPoss = context.Possession.Get.Where(x => x.Flat == flat);
            return FlatPoss.Where(x => x.Owner == person).Sum(x => x.Size) / FlatPoss.Sum(x => x.Size);
        }

        public IEnumerable<Service> GetServicesByPerson(Person person)
        {
            var Poss = GetPossessionsByPerson(person);
            var res = new List<Service>();
            foreach (var curPoss in Poss)
            {
                foreach (var service in context.Services.Get.Where(x => x.Flat == curPoss.Flat && x.Date >= curPoss.Start && x.Date <= curPoss.End )) res.Add(service);
            }
            return res;
        }

        public IEnumerable<Possession> GetPossessionsByPerson(Person person)
        {
            return context.Possession.Get.Where(x => x.Owner == person).ToList();
        }

        public IEnumerable<Possession> GetPossessionsByFlat(Flat flat)
        {
            return context.Possession.Get.Where(x => x.Flat == flat).ToList();
        }

    }
}