using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApplication.Controllers
{
    public class ValuesController : ApiController
    {
        //static NewShowRoomEntities1 DbContext;
        //public ValuesController()
        //{
        //    DbContext = new NewShowRoomEntities1();
        //}

        // GET api/values
        public List<Product> Get()
        {
            using (NewShowRoomEntities1 en = new NewShowRoomEntities1())
            {
                return  en.Products.ToList();
                //Added code
            }
            
        }

        // GET api/values/5
        public Product Get(int id)
        {
          using(NewShowRoomEntities1 en=new NewShowRoomEntities1())
          {
                return en.Products.FirstOrDefault(e => e.ProductId == id);
            }
            
        }

        // POST api/values
        public void Post([FromBody] Product p)
        {

            using (NewShowRoomEntities1 en = new NewShowRoomEntities1())
            {
                en.Products.Add(p);
                en.SaveChanges();
            }
            
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] Product p)
        {
            using (NewShowRoomEntities1 en1 = new NewShowRoomEntities1())
            {
                var result1 = (from E in en1.Products where E.ProductId == id select E).FirstOrDefault();
                if (result1 != null)
                {

                    
                    result1.ProductName = p.ProductName;
                    result1.Quantity = p.Quantity;
                    result1.Price = p.Price;
                    en1.SaveChanges();

                }
            }
            return "Product Updated";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            using (NewShowRoomEntities1 en = new NewShowRoomEntities1())
            {
                var result = (from E in en.Products where E.ProductId == id select E).FirstOrDefault();
                if (result != null)
                {
                    en.Products.Remove(result);
                    en.SaveChanges();

                    
                }
            }
            return "Deleted Successfully";
        }
    }
}
