using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        //Stores lists of products
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null){
                products = new List<Product>();
            }
        } 
        //Saves products in computer memory
        public void Commit(){
            cache["products"] = products;
        }

        //Allows the insert and save of products
        public void Insert (Product p){
            products.Add(p);
        }

        //Allows updating of products.If none exist, throws exception
        public void Update(Product product){
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("No Product Found");
            }

         }

        //Allows updating of products.If none exist, throws exception
        public Product Find(string Id){
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("No Product Found");
            }
        }

        //Allows product list to be searchable
        public IQueryable<Product> Collection(){
            return products.AsQueryable();
        }

        //Allows deleting of products. If none exist, throws exception
        public void Delete (String Id){
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("No Product Found");
            }
        }
    }
}
