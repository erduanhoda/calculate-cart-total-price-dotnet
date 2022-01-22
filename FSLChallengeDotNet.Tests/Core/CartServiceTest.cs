using System;
using System.Collections.Generic;
using FSLChallengeDotNet.Core.Dto.CartDTO;
using FSLChallengeDotNet.Core.Entities;
using FSLChallengeDotNet.Core.Exceptions;
using FSLChallengeDotNet.Core.Interfaces;
using FSLChallengeDotNet.Core.Services;
using Moq;
using Xunit;

namespace FSLChallengeDotNet.Tests.Core
{
    public class CartServiceTest
    {
        [Fact]
        public void Should_Fail_With_ALL_Empty_Guids()
        {
            var mockRepository = new Mock<IRepository>();

            var list = new List<CartItem>();

            mockRepository.Setup(i => i.AddAsync(It.IsAny<CartItem>())).Callback((CartItem item) => list.Add(item));

            var service = new CartService(mockRepository.Object);

            var exp = Record.Exception(() => service.Add(AddItemInput.Instance(new Guid(), new Guid())).GetAwaiter().GetResult());
            Assert.IsType<ArgumentNullException>(exp);
        }

        [Fact]
        public void Should_Fail_With_One_Empty_Guid()
        {
            var mockRepository = new Mock<IRepository>();

            var list = new List<CartItem>();

            mockRepository.Setup(i => i.AddAsync(It.IsAny<CartItem>())).Callback((CartItem item) => list.Add(item));

            var service = new CartService(mockRepository.Object);

            var exp = Record.Exception(() => service.Add(AddItemInput.Instance(new Guid("f5e4f603-d6fb-412b-8478-6995f43b733d"), new Guid())).GetAwaiter().GetResult());
            Assert.IsType<ArgumentNullException>(exp);
        }

        [Fact]
        public void Should_Pass_With_Both_Guids()
        {
            var mockRepository = new Mock<IRepository>();

            var list = new List<CartItem>();

            mockRepository.Setup(i => i.AddAsync(It.IsAny<CartItem>())).Callback((CartItem item) => list.Add(item));

            var service = new CartService(mockRepository.Object);

            var exp = Record.Exception(() => service.Add(AddItemInput.Instance(new Guid("f5e4f603-d6fb-412b-8478-6995f43b733d"), new Guid("6694f0d0-1331-41f6-8e18-55eb8453bda8"))).GetAwaiter().GetResult());
            Assert.IsNotType<ArgumentNullException>(exp);
        }

        [Fact]
        public void Should_Not_Add_Unexisting_CartItem()
        {
            var mockRepository = new Mock<IRepository>();

            var list = new List<CartItem>();

            mockRepository.Setup(i => i.AddAsync(It.IsAny<CartItem>())).Callback((CartItem item) => list.Add(item));

            var service = new CartService(mockRepository.Object);

            var exp = Record.Exception(() => service.Add(AddItemInput.Instance(new Guid("f5e4f603-d6fb-412b-8478-6995f43b733d"), new Guid("6694f0d0-1331-41f6-8e18-55eb8453bda8"))).GetAwaiter().GetResult());
            Assert.IsType<ObjectException>(exp);
        }
    }
}
