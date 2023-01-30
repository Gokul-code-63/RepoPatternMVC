using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternMVC.Models.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int ProductId);
        void InsertProduct(Product product_);
        void UpdateProduct(Product product_);
        void DeleteProduct(int ProductId);
        void SaveChanges();
    }
}
