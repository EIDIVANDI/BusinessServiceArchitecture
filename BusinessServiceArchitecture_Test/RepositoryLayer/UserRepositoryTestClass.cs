using System;
using NUnit.Framework;
using BusinessServiceArchitecture_Repository.User;
using BusinessServiceArchitecture_Data;
using Moq;
using System.Collections.Generic;
using BusinessServiceArchitecture_Data.DataEntities;

namespace BusinessServiceArchitecture_Test.RepositoryLayer
{
    [TestFixture]
    public class UserRepositoryTestClass
    {
        [Test]
        [Category("UserRepository")]
        public void USER_REPOSITORY_CREATION_TEST()
        {
            //Given 
            IUserRepository actual;

            //When
            actual = new UserRepository();

            //Then
            Assert.IsInstanceOf<IUserRepository>(actual);
        }

        [Test]
        [Category("UserRepository")]
        public void User_REPOSITORY_GETSINGLE_ID_ONE_TYPE_TEST()
        {
            //Given 
            BaseEntity actual = null;
            Mock<IUserRepository> _Repository = new Mock<IUserRepository>();


            _Repository.Setup(x => x.GetSingle(c => c.Id == 1))
                .Returns(new BusinessServiceArchitecture_Data.DataEntities.User { Id = 1 });


            //When
            actual = _Repository.Object.GetSingle(e => e.Id == 1);

            //Then
            Assert.IsInstanceOf<BaseEntity>(actual);
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);

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
