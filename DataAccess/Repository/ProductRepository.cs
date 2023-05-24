using DataAccess.DataAcces;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductByID(int productId) => ProductDAO.Instance.GetproductByID(productId);
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetproductList();
        public void InsertProduct(Product Product) => ProductDAO.Instance.AddNew(Product);
        public void DeleteProduct(int productId) => ProductDAO.Instance.Remove(productId);
        public void UpdateProduct(Product Product) => ProductDAO.Instance.Update(Product);
    }
}
