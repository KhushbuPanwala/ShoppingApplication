using Microsoft.EntityFrameworkCore;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        ProductDatabaseContext db = new ProductDatabaseContext();

        private IDatabaseContext DbContext;

        public ProductDetailRepository(IDatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get all product details
        /// </summary>
        /// <returns>count of products</returns>
        public async Task<int> GetAllProductsAsync()
        {
            int productDetailsCount = await DbContext.Count<ProductDetail>();

            if (productDetailsCount == 0)
            {
                throw new Exception($"No Product available.");
            }

            return productDetailsCount;
        }

        /// <summary>
        /// Get product details by given id
        /// <param name="id">id of product detail </param>
        /// </summary>
        /// <returns>product details for given id</returns>
        public async Task<ProductDetail> GetProductsAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Must specify a product id.", nameof(id));
            }

            ProductDetail productDetail = await DbContext.FindSingleAsync<ProductDetail>(id);

            if (productDetail == null)
            {
                throw new Exception($"Product  '{id}' was not found.");
            }

            return productDetail;
        }

        /// <summary>
        /// Add new product details 
        /// <param name="model">product detail saved in database</param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<bool> DeleteProductsAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Must specify a product id.", nameof(id));
            }

            bool isDeleted = await DbContext.DeleteSingleAsync<ProductDetail>(id);

            if (!isDeleted)
            {
                throw new Exception($"Product  '{id}' was not found.");
            }

            return isDeleted;
        }

        /// <summary>
        /// Update product details 
        /// <param name="model">updated product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<bool> UpdateProductsAsync(int id, ProductDetail productDetail)
        {
            if (id == 0)
            {
                throw new ArgumentException("Must specify a product id.", nameof(id));
            }

            bool isUpdated = await DbContext.UpdateSingleAsync<ProductDetail>(id, productDetail);

            if (!isUpdated)
            {
                throw new Exception($"Product  '{id}' was not found.");
            }

            return isUpdated;
        }

        /// <summary>
        /// Delete product details 
        /// <param name="id">id of delete product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<ProductDetail> AddProductsAsync(ProductDetail productDetail)
        {
            if (productDetail == null)
            {
                throw new ArgumentException("Invalid product");
            }

            ProductDetail product = await DbContext.AddSingleAsync<ProductDetail>(productDetail);

            if (product.Id == 0)
            {
                throw new Exception($"Product was not saved.");
            }

            return product;
        }


        #region database operation
        /// <summary>
        /// Get all product details
        /// </summary>
        /// <returns>list of product details</returns>
        public async Task<List<ProductDetail>> GetAllProductDetail()
        {
            List<ProductDetail> productDetailList = new List<ProductDetail>();
            return await (from a in db.ProductDetail
                          select new ProductDetail
                          {
                              Id = a.Id,
                              ProductName = a.ProductName,
                              ProductCode = a.ProductCode,
                              Manufacturer = a.Manufacturer,
                              ShippingNo = a.ShippingNo,
                              SerialNo = a.SerialNo,
                              BatchNo = a.BatchNo,
                              MRP = a.MRP,
                              Quantity = a.Quantity
                          }).ToListAsync();
        }
       
        /// <summary>
        /// Get product details by given id
        /// <param name="id">id of product detail </param>
        /// </summary>
        /// <returns>product details for given id</returns>
        public async Task<ProductDetail> GetProductDetailById(int id)
        {
            ProductDetail productDetail = db.ProductDetail.Where(x => x.Id == id).FirstOrDefault();
            return productDetail;
        }
        
        /// <summary>
        /// Add new product details 
        /// <param name="model">product detail saved in database</param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<bool> AddProductDetail(ProductDetail productDetail)
        {

            productDetail.CreatedOn = System.DateTime.Now;
            productDetail.LastModifiedOn = System.DateTime.Now;

            db.ProductDetail.Add(productDetail);
            return await db.SaveChangesAsync() >= 1;
        }
        
        /// <summary>
        /// Update product details 
        /// <param name="model">updated product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<bool> UpdateProductDetail(ProductDetail productdata)
        {
            ProductDetail productDetail = db.ProductDetail.Where
                      (x => x.Id == productdata.Id).FirstOrDefault();
            if (productDetail != null)
            {
                productDetail.ProductName = productdata.ProductName;
                productDetail.ProductCode = productdata.ProductCode;
                productDetail.Manufacturer = productdata.Manufacturer;
                productDetail.ShippingNo = productdata.ShippingNo;
                productDetail.SerialNo = productdata.SerialNo;
                productDetail.BatchNo = productdata.BatchNo;
                productDetail.MRP = productdata.MRP;
                productDetail.Quantity = productdata.Quantity;
                productDetail.CreatedOn = System.DateTime.Now;
                productDetail.LastModifiedOn = System.DateTime.Now;
                await db.SaveChangesAsync();

            }
            return true;
        }
       
        /// <summary>
        /// Delete product details 
        /// <param name="id">id of delete product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        public async Task<bool> DeleteProductDetail(int id)
        {
            ProductDetail productDetail = db.ProductDetail.Where(x => x.Id == id).FirstOrDefault();
            if (productDetail != null)
            {
                db.ProductDetail.Remove(productDetail);
            }
            return await db.SaveChangesAsync() >= 1;
        }
        #endregion
    }
}
