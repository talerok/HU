using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HU.Logic
{
    public class Calculator
    {
        ContextHelper helper;

        public Calculator(ContextHelper help)
        {
            helper = help;
        }

        public decimal Get(Models.Services.Service service, Models.Person person)
        {
            
            if (service.Info.paymentType.Type == 0)
            {
                decimal pl = helper.GetPersonFlatProportion(person, service.Flat);
                return service.Info.Price * service.Count * pl;
            }
            else if (service.Info.paymentType.Type == 1)
            {
                decimal pl = helper.GetPersonFlatProportion(person, service.Flat);
                return service.Info.Price * service.Count * helper.GetFlatPeopleCount(service.Flat) * pl;
            }
            else if(service.Info.paymentType.Type == 2)
            {
                var res = helper.GetPossessionsByPerson(person).Where(x => x.Flat == service.Flat).Sum(x => x.Size);
                return service.Info.Price * res * service.Count;
            }
            else return 0;
        }
    }
}