using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices;
using JamesAlcaraz.NlayeredAppDemo.Application.Dto;
using JamesAlcaraz.NlayeredAppDemo.Core.Entities;
using JamesAlcaraz.NlayeredAppDemo.Core.Repositories;
using JamesAlcaraz.NlayeredAppDemo.Core.Uow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JamesAlcaraz.NlayeredAppDemo.UnitTest.Application
{
    [TestClass]
    public class ProductAppServiceTest
    {
        private static Mock<IRepository<Product>> CreateProductRepository()
        {
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(x => x.Insert(It.IsAny<Product>())).Returns(new Product());
            return mockRepo;
        }

        private static Mock<IUnitOfWork> CreateUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.Commit()).Returns(1);
            return mockUow;
        }

        [TestMethod]
        public void Create_ValidParamater_ReturnsNewInstance()
        {
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(x => x.Insert(It.IsAny<Product>())).Returns(new Product());
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.Commit()).Returns(1);

            var productService = new ProductAppService(mockUow.Object, mockRepo.Object);
            
            var result = productService.CreateProduct(new ProductInput());

            mockRepo.Verify(x => x.Insert(It.IsAny<Product>()));
            mockUow.Verify(x => x.Commit());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_NullParamater_ThrowsException()
        {
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(x => x.Insert(It.IsAny<Product>())).Returns(new Product());
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.Commit()).Returns(1);

            var productService = new ProductAppService(mockUow.Object, mockRepo.Object);

            productService.CreateProduct(null);
        }

    }
}
