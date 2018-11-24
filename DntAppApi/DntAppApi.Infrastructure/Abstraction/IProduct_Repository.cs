using DntAppApi.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DntAppApi
{
    public interface IProduct_Repository : IDisposable
    {
        IQueryable<TblProduct> GetAll();
        void Save(TblProduct obj);
        void Remove(int Productid);
    }
}