using DataAccess.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetproductList()
        {
            var products = new List<Product>();
            try
            {
                using var context = new FStoreContext();
                products = context.Products.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;
        }

        public Product GetproductByID(int ProductId)
        {
            Product product = null;
            try
            {
                using var context = new FStoreContext();
                product = context.Products.SingleOrDefault(c => c.ProductId == ProductId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetproductByID(product.ProductId);
                if (_product == null)
                {
                    using var context = new FStoreContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product _product = GetproductByID(product.ProductId);
                if (_product != null)
                {
                    using var context = new FStoreContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Remove(int ProductId)
        {
            try
            {
                Product product = GetproductByID(ProductId);
                if (product != null)
                {
                    using var context = new FStoreContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<Product> GetProductByName(string productName)
        {
            IEnumerable<Product> products = null;
            try
            {
                using var context = new FStoreContext();
                products = context.Products.Where(x => x.ProductName.Contains(productName)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}
