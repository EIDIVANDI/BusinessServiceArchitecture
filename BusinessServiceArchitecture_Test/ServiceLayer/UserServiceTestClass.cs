using System;
using NUnit.Framework;
using BusinessServiceArchitecture_Servic.User;
using Moq;
using BusinessServiceArchitecture_Data;
using BusinessServiceArchitecture_Repository.User;
using System.Collections.Generic;
using BusinessServiceArchitecture_Domain;
using System.Linq.Expressions;
using BusinessServiceArchitecture_Data.DataEntities;
using BusinessServiceArchitecture_Domain.Order;

namespace BusinessServiceArchitecture_Test.ServiceLayer
{
    [TestFixture]
    public class UserServiceTestClass
    {
        [Test]
        [Category("UserService")]
        public void USER_SERVICE_CREATION_TEST()
        {
            //Given 
            IUserService actual;

            //When
            actual = new UserService();

            //Then
            Assert.IsInstanceOf<IUserService>(actual);

        }

        [Test]
        [Category("UserService")]
        public void USER_SERVICE_DEPENDENCE_CREATION_TEST()
        {
            //Given 
            IUserService actual;
            Mock<IUserRepository> _Repository = new Mock<IUserRepository>();

            //When
            actual = new UserService(_Repository.Object);

            //Then
            Assert.IsInstanceOf<IUserService>(actual);

        }

        [Test]
        [Category("UserService")]
        public void USER_SERVICE_GET_LAST_ORDER_TEST()
        {
            //Given 
            DomainBaseEntity actual;
            IEnumerable<Order> entity = new List<Order> { new Order { Id = 1 } };
            Mock<IUserRepository> _Repository = new Mock<IUserRepository>();

            _Repository.Setup(m => m.OrdersHistory(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(entity).Verifiable();

            UserService _Service = new UserService(_Repository.Object);

            //When
            actual = _Service.GetUserLastOrderDetails(1);

            //Then
            _Repository.Verify();
            Assert.IsInstanceOf<DomainBaseEntity>(actual);
            Assert.IsInstanceOf<OrderModel>(actual);
            Assert.IsNotNull(actual); 
        }

        [Test]
        [Category("UserRepository")]
        public void User_REPOSITORY_Get_ORDERS_FOR_USER_TEST()
        {
            //Given 
            IEnumerable<Order> actual;
            Mock<IUserRepository> _Repository = new Mock<IUserRepository>();


            _Repository.Setup(x => x.OrdersHistory(c => c.Id == 1))
                .Returns(new List<Order> {
                    new Order {
                        Id = 1,
                        OrderDate = DateTime.Now.Date,
                        OrderTotalPrice = 1000,
                        User = new User{
                            Id =1,
                            Email ="email@mail.com",
                            Name ="Name"
                        }
                    }
                });


            //When
            actual = _Repository.Object.OrdersHistory(e => e.Id == 1);

            //Then
            Assert.IsInstanceOf<IEnumerable<Order>>(actual);
            Assert.IsInstanceOf<IList<Order>>(actual);
            Assert.IsNotNull(actual);
            Assert.IsNotEmpty(actual);
        }

    }
}
