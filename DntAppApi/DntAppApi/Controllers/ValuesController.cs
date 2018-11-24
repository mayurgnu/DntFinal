using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DntAppApi.core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DntAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // TEST GET api/values
        IProduct_Repository _IProduct_Repository = new Product_Repository(new MPContext());

        [HttpGet]
        public IQueryable<TblProduct> Get()
        {
            return _IProduct_Repository.GetAll();
        }

        [HttpPost]
        public TblProduct Post(TblProduct obj)
        {
            _IProduct_Repository.Save(obj);
            return obj;
        }
        [HttpPut]
        public TblProduct Put(TblProduct obj)
        {
            _IProduct_Repository.Save(obj);
            return obj;
        }
        [HttpDelete]
        public int Delete(int Productid)
        {
            _IProduct_Repository.Remove(Productid);
            return 1;
        }
    }
}
