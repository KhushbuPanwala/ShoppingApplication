using Moq;
using ShoppingApp;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class ProductServiceTests
    {
        private TestingObject<ProductDetailRepository> GetTestingObject()
        {
            var testingObject = new TestingObject<ProductDetailRepository>();
            testingObject.AddDependency(new Mock<IDatabaseContext>(MockBehavior.Strict));
            return testingObject;
        }

        #region Get all Product
        [Fact]
        public async Task GetAll_ProductNotFound_ThrowsException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();
            int count = 0;

            mockDbContext
           .Setup(dbc => dbc.Count<ProductDetail>()).ReturnsAsync(count);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            await Assert.ThrowsAsync<Exception>(async ()
                => await productDetailRepository.GetAllProductsAsync());
        }
        [Fact]
        public async Task GetAllProduct_Success_ReturnsCorrectResult()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();
            int count = 3;

            mockDbContext
                .Setup(dbc => dbc.Count<ProductDetail>())
                .ReturnsAsync(count);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            int result = await productDetailRepository.GetAllProductsAsync();

            Assert.Equal(count, result);
        }
        #endregion

        #region Get product by id unit test
        [Fact]
        public async Task Get_InvalidArgument_ThrowsArgumentException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            int productId = 0;
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await productDetailRepository.GetProductsAsync(productId));
        }
        [Fact]
        public async Task Get_ProductNotFound_ThrowsException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 3;
            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();

            ProductDetail productDetail = null;
            mockDbContext
           .Setup(dbc => dbc.FindSingleAsync<ProductDetail>(productId)).ReturnsAsync(productDetail);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            await Assert.ThrowsAsync<Exception>(async ()
                => await productDetailRepository.GetProductsAsync(productId));
        }
        [Fact]
        public async Task GetProduct_Success_ReturnsCorrectResult()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 1003;

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();

            ProductDetail productDetail = new ProductDetail
            {
                ProductName = "Vivo",
                ProductCode = "5001"
            };
            mockDbContext
                .Setup(dbc => dbc.FindSingleAsync<ProductDetail>(productId))
                .ReturnsAsync(productDetail);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            ProductDetail result = await productDetailRepository.GetProductsAsync(productId);

            Assert.Equal(productDetail.ProductName, result.ProductName);
            Assert.Equal(productDetail.ProductCode, result.ProductCode);
        }
        #endregion

        #region Delete product by id unit test
        [Fact]
        public async Task Delete_InvalidArgument_ThrowsArgumentException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            int productId = 0;
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await productDetailRepository.DeleteProductsAsync(productId));
        }
        [Fact]
        public async Task Delete_ProductNotFound_ThrowsException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 3;
            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();

            bool isDeleted = false;
            mockDbContext
           .Setup(dbc => dbc.DeleteSingleAsync<ProductDetail>(productId)).ReturnsAsync(isDeleted);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            await Assert.ThrowsAsync<Exception>(async ()
                => await productDetailRepository.DeleteProductsAsync(productId));
        }
        [Fact]
        public async Task DeleteProduct_Success_ReturnsCorrectResult()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 1003;

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();
            bool isDeleted = true;

            mockDbContext
                .Setup(dbc => dbc.DeleteSingleAsync<ProductDetail>(productId))
                .ReturnsAsync(isDeleted);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            bool result = await productDetailRepository.DeleteProductsAsync(productId);

            Assert.Equal(isDeleted, result);
        }
        #endregion

        #region update product unit test
        [Fact]
        public async Task Update_InvalidArgument_ThrowsArgumentException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            int productId = 0;

            ProductDetail productDetail = new ProductDetail
            {
                ProductName = "Iphone",
                ProductCode = "10001",
                Manufacturer = "apple",
                ShippingNo = "1001",
                SerialNo = 1010,
                BatchNo = "B10001",
                MRP = 500,
                Quantity = 3
            };
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await productDetailRepository.UpdateProductsAsync(productId, productDetail));
        }
        [Fact]
        public async Task Update_ProductNotFound_ThrowsException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 3;
            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();

            bool isDeleted = false;

            ProductDetail productDetail = new ProductDetail
            {
                Id = 3,
                ProductName = "Iphone",
                ProductCode = "10001",
                Manufacturer = "apple",
                ShippingNo = "1001",
                SerialNo = 1010,
                BatchNo = "B10001",
                MRP = 500,
                Quantity = 3
            };

            mockDbContext
           .Setup(dbc => dbc.UpdateSingleAsync<ProductDetail>(productId, productDetail)).ReturnsAsync(isDeleted);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            await Assert.ThrowsAsync<Exception>(async ()
                => await productDetailRepository.UpdateProductsAsync(productId, productDetail));
        }
        [Fact]
        public async Task UpdateProduct_Success_ReturnsCorrectResult()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            int productId = 1003;

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();
            bool isDeleted = true;
            ProductDetail productDetail = new ProductDetail
            {
                Id = 1003,
                ProductName = "Iphone",
                ProductCode = "10001",
                Manufacturer = "apple",
                ShippingNo = "1001",
                SerialNo = 1010,
                BatchNo = "B10001",
                MRP = 500,
                Quantity = 3
            };
            mockDbContext
                .Setup(dbc => dbc.UpdateSingleAsync<ProductDetail>(productId, productDetail))
                .ReturnsAsync(isDeleted);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            bool result = await productDetailRepository.UpdateProductsAsync(productId, productDetail);

            Assert.Equal(isDeleted, result);
        }
        #endregion

        #region Add product unit test
        [Fact]
        public async Task Add_InvalidArgument_ThrowsArgumentException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();

            ProductDetail productDetail = null;
            await Assert.ThrowsAsync<ArgumentException>(async () =>
                await productDetailRepository.AddProductsAsync(productDetail));
        }

        [Fact]
        public async Task Add_ProductNotFound_ThrowsException()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();

            ProductDetail productDetail = new ProductDetail
            {
                ProductName = "Iphone",
                ProductCode = "10001",
                Manufacturer = "apple",
                ShippingNo = "1001",
                SerialNo = 1010,
                BatchNo = "B10001",
                MRP = 500,
                Quantity = 3
            };

            mockDbContext
           .Setup(dbc => dbc.AddSingleAsync<ProductDetail>(productDetail)).ReturnsAsync(productDetail);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            await Assert.ThrowsAsync<Exception>(async ()
                => await productDetailRepository.AddProductsAsync(productDetail));
        }
        [Fact]
        public async Task AddProduct_Success_ReturnsCorrectResult()
        {
            TestingObject<ProductDetailRepository> testingObject = this.GetTestingObject();

            var mockDbContext = testingObject.GetDependency<Mock<IDatabaseContext>>();
            ProductDetail productDetail = new ProductDetail
            {
                Id = 1003,
                ProductName = "Iphone",
                ProductCode = "10001",
                Manufacturer = "apple",
                ShippingNo = "1001",
                SerialNo = 1010,
                BatchNo = "B10001",
                MRP = 500,
                Quantity = 3
            };
            mockDbContext
                .Setup(dbc => dbc.AddSingleAsync<ProductDetail>(productDetail))
                .ReturnsAsync(productDetail);

            ProductDetailRepository productDetailRepository = testingObject.GetResolvedTestingObject();
            ProductDetail result = await productDetailRepository.AddProductsAsync(productDetail);
            Assert.Equal(productDetail.ProductName, result.ProductName);
            Assert.Equal(productDetail.ProductCode, result.ProductCode);
        }
        #endregion
    }
}
