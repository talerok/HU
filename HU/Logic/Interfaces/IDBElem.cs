using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HU.Logic.Interfaces
{
    public interface IDBElem<T>
    {
        void Add(T add);
        void Dell(T del);
        void Edited(T edt);
        IEnumerable<T> Get { get; }

    }
}