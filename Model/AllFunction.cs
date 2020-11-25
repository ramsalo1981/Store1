using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model
{
    public interface AllFunction<TClass>
    {
        List<TClass> GetAll();
        void Add(TClass tClass);
        TClass Find(int id);
        void Edit(TClass tClass, int id);
        void Delete(int id);

    }
}
