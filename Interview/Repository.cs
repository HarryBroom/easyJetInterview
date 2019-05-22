using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class Repository : IRepository<T>
    {
        private readonly IList<T> _entities = new List<T>();

        public IEnumerable<T> All()
        {
            return _entities.ToList();
        }

        public void Delete(T item)
        {
            if (_entities.FirstOrDefault(x => Equals(x.Id, item.Id)) != null)
                _entities.Remove(_entities.Single(e => Equals(e.Id, item.Id)));
            else
                throw new InvalidOperationException("Item all ready exists in the repo");
        }

        public T FindById(IComparable id)
        {
            return _entities.SingleOrDefault(e => Equals(e.Id, id));
        }

        public void Save(T item)
        {
            if (_entities.FirstOrDefault(x => Equals(x.Id, item.Id)) == null)
                _entities.Add(item);
            else
                throw new InvalidOperationException("Item all ready exists in the Repo");
        }

        public void SaveAll(List<T> items)
        {
            foreach (var item in items)
            {
                if (_entities.FirstOrDefault(x => Equals(x.Id, item.Id)) == null)
                    _entities.Add(item);
                else
                    throw new InvalidOperationException("Item All Ready Exists in the list");
            }
        }
    }
    public class T : IStoreable
    {
        public IComparable Id { get; set; }
    }
}
