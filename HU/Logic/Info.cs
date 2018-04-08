using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HU.Models;
using HU.Models.Services;

namespace HU.Logic
{
    public static class Info
    {
        public static Interfaces.IContext DB
            = new EntityContext("kurochkin-414");
        public static ContextHelper contextHelper
            = new ContextHelper(DB);
        public static Checker Checker = new Checker("blablablasalt");

        public static Calculator Calculator = new Calculator(contextHelper);

    }
}