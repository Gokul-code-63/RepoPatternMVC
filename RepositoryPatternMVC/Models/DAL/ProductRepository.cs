using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPatternMVC.Models.DAL
{
    //classimplemented through interface IProductRepository
    public class ProductRepository : IProductRepository,IDisposable
    {
        //declate private variable of type dbcontext
        private RepoPatternTestDbEntities _repoPatternTestDbEntities;

        //Dependency Injection using ctor by passing in dbcontext obj
        public ProductRepository(RepoPatternTestDbEntities repoPatternTestDbEntities)
        {
            this._repoPatternTestDbEntities = repoPatternTestDbEntities;
        }

        //genetic action methods
        public void DeleteProduct(int ProductId)
        {
            Product product_ = _repoPatternTestDbEntities.Products.Find(ProductId);
            _repoPatternTestDbEntities.Products.Remove(product_);
        }

        public Product GetProductById(int ProductId)
        {
            return _repoPatternTestDbEntities.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repoPatternTestDbEntities.Products.ToList();
        }

        public void InsertProduct(Product product_)
        {
            _repoPatternTestDbEntities.Products.Add(product_);
        }

        public void SaveChanges()
        {
            _repoPatternTestDbEntities.SaveChanges();
        }

        public void UpdateProduct(Product product_)
        {
            _repoPatternTestDbEntities.Entry(product_).State = System.Data.Entity.EntityState.Modified;
        }

        //Idisposable interface implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repoPatternTestDbEntities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}