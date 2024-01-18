using DeviationModule.Models.Interfaces;
using DeviationModule.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.Services
{
    public abstract class RepoInMemory<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _Items = new();
        private int LastId;

        protected RepoInMemory() { }
        protected RepoInMemory(IEnumerable<T> Items)
        {

            foreach (var item in Items)
            {
                Add(item);
            }
        }
        public void Add(T entity)
        {
            if (entity==null) throw new ArgumentNullException(nameof(entity));
            if (_Items.Contains(entity)) return;
            entity.Id = ++ LastId;
            _Items.Add(entity);
        }

        public T Get(int id) => Get(id);

        public IEnumerable<T> GetAll() => _Items;

        public void Remove(T entity)
        {
            if (_Items.Contains(entity)) _Items.Remove(entity);
        }
        public void Update(int id,T entity)
        {
            var destination = ((IRepository<T>)this).Get(id);
            if (destination != null)
            {
                Update(entity,destination);
            }
        }
        public abstract void Update(T Source, T Destination);
    }
}
