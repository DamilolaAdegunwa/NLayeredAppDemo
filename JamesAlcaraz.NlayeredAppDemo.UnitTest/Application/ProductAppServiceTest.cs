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
        [TestMethod]
        public void Create_ValidParamater_ReturnsNewInstance()
        {
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(x => x.Insert(It.IsAny<Product>())).Returns(new Product());
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.Commit()).Returns(1);

            var productService = new ProductAppService(mockUow.Object, mockRepo.Object);
            
            var result = productService.Create(new ProductCreateInput());

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

            productService.Create(null);
        }

    }
}
