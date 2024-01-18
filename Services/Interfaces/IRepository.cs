using DeviationModule.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace DeviationModule.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity 
    {
        IEnumerable<T> GetAll();
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);

        void Remove(T entity);
        void Add(T entity);
        void Update(int id, T entity);

    }

}
