using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public interface IProductDetailRepository
    {
        #region database updation methods
        /// <summary>
        /// Get all product details
        /// </summary>
        /// <returns>list of product details</returns>
        Task<List<ProductDetail>> GetAllProductDetail();

        /// <summary>
        /// Get product details by given id
        /// <param name="id">id of product detail </param>
        /// </summary>
        /// <returns>product details for given id</returns>
        Task<ProductDetail> GetProductDetailById(int id);

        /// <summary>
        /// Add new product details 
        /// <param name="model">product detail saved in database</param>
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> AddProductDetail(ProductDetail productDetail);

        /// <summary>
        /// Update product details 
        /// <param name="model">updated product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> UpdateProductDetail(ProductDetail productDetail);

        /// <summary>
        /// Delete product details 
        /// <param name="id">id of delete product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> DeleteProductDetail(int id);
        #endregion


        /// <summary>
        /// Get all product details
        /// </summary>
        /// <returns>count of products</returns>
        Task<int> GetAllProductsAsync();

        /// <summary>
        /// Get product details by given id
        /// <param name="id">id of product detail </param>
        /// </summary>
        /// <returns>product details for given id</returns>
        Task<ProductDetail> GetProductsAsync(int id);

        /// <summary>
        /// Add new product details 
        /// <param name="model">product detail saved in database</param>
        /// </summary>
        /// <returns>Task</returns>
        Task<ProductDetail> AddProductsAsync(ProductDetail productDetail);

        /// <summary>
        /// Update product details 
        /// <param name="model">updated product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> UpdateProductsAsync(int id, ProductDetail productDetail);

        /// <summary>
        /// Delete product details 
        /// <param name="id">id of delete product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> DeleteProductsAsync(int id);
    }

}
