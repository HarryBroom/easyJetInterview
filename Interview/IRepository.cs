using System;
using System.Collections.Generic;

namespace Interview
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<T> 
    {
        IEnumerable<T> All();
        void Delete(Interview.T id);
        void Save(T item);
        T FindById(IComparable id);
    }
}
