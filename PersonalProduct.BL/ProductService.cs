using PersonalCompany.PersonalProduct.DAL;
using PersonalCompany.PersonalProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCompany.PersonalProduct.BL
{
    public class ProductService
    {
        public List<Product> GetAll()
        {
            ProductRepository ProductRepo = new ProductRepository();
            return ProductRepo.GetList().Result.ToList();
        }

        public Product GetById(int id)
        {
            ProductRepository ProductRepo = new ProductRepository();
            return ProductRepo.Get<Product>(id).Result;
        }

        public int Add(Product product)
        {
            ProductRepository ProductRepo = new ProductRepository();
            product.Active = true;
            Task<int> n = ProductRepo.Insert<Product>(product);
            return n.Result;
        }
        public int Update(Product product)
        {
            ProductRepository ProductRepo = new ProductRepository();
            Task<int> n = ProductRepo.Update<Product>(product);
            return n.Result;
        }

        public int Delete(int id)
        {
            ProductRepository ProductRepo = new ProductRepository();
            Task<int> n = ProductRepo.Delete(id);
            return n.Result;
        }
    }
}
