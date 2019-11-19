using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public IProductDetailRepository productDetailRepository;

        public ProductController(IProductDetailRepository productDetailRepo)
        {
            productDetailRepository = productDetailRepo;
        }

        /// <summary>
        /// Get all product details
        /// </summary>
        /// <returns>list of product details</returns>
        [HttpGet]
        [Route("GetProductDetails")]
        public async Task<List<ProductDetail>> GetProductDetails()
        {
            return await productDetailRepository.GetAllProductDetail();
        }

        /// <summary>
        /// Get product details by given id
        /// <param name="id">id of product detail </param>
        /// </summary>
        /// <returns>product details for given id</returns>
        [HttpPost]
        [Route("GetProductDetailById")]
        public async Task<ProductDetail> GetProductDetailById([FromBody] int id)
        {
            return await productDetailRepository.GetProductDetailById(id);
        }

        /// <summary>
        /// Add new product details 
        /// <param name="model">product detail saved in database</param>
        /// </summary>
        /// <returns>Task</returns>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDetail model)
        {
            return Json(await productDetailRepository.AddProductDetail(model));
        }

        /// <summary>
        /// Update product details 
        /// <param name="model">updated product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDetail model)
        {
            return Json(await productDetailRepository.UpdateProductDetail(model));
        }

        /// <summary>
        /// Delete product details 
        /// <param name="id">id of delete product detail </param>
        /// </summary>
        /// <returns>Task</returns>
        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] int id)
        {
            return Json(await productDetailRepository.DeleteProductDetail(id));
        }
    }
}
