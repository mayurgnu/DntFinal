using DntAppApi.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DntAppApi
{
    public class Product_Repository : IProduct_Repository
    {
        private MPContext context;
        public Product_Repository(MPContext _context)
        {
            context = _context;
        }

        public IQueryable<TblProduct> GetAll()
        {
            return context.TblProduct.AsQueryable();
        }
        public void Save(TblProduct obj)
        {
            if (obj.Productid == 0)
            {
                context.TblProduct.Add(obj);
                context.SaveChanges();
            }
            else
            {
                context.Entry<TblProduct>(obj).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void Remove(int Productid)
        {
            var obj = context.TblProduct.Find(Productid);
            context.Entry<TblProduct>(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                context.Dispose();
            }

            // Free any unmanaged objects here.
            disposed = true;
        }
    }
}
