using BusinessServiceArchitecture_Data;
using BusinessServiceArchitecture_Domain;
using System.Linq.Expressions;
using BusinessServiceArchitecture_Repository;
using BusinessServiceArchitecture_Servic.Generic;
using Moq;
using NUnit.Framework;
using System;

namespace BusinessServiceArchitecture_Test.ServiceLayer
{
    [TestFixture]
    public class GenericServiceTestClass
    {
        [Test]
        [Category("GenericService")]
        public void GENERIC_SERVICE_CREATION_TEST()
        {
            //Given 
            IGenericService actual;

            //When
            actual = new GenericService();

            //Then
            Assert.IsInstanceOf<IGenericService>(actual);

        }

        [Test]
        [Category("GenericService")]
        public void GENERIC_SERVICE_DEPENDENCE_CREATION_TEST()
        {
            //Given 
            IGenericService actual;
            Mock<IGenericRepository<BaseEntity>> _Repository = new Mock<IGenericRepository<BaseEntity>>();
            
            //When
            actual = new GenericService(_Repository.Object);

            //Then
            Assert.IsInstanceOf<IGenericService>(actual);

        }

        [Test]
        [Category("GenericService")]
        public void GENERIC_SERVICE_GET_ITEM_TEST()
        {
            //Given 
            DomainBaseEntity actual;
            BaseEntity entity = new BaseEntity { Id = 1 };
            Mock<IGenericRepository<BaseEntity>> _Repository = new Mock<IGenericRepository<BaseEntity>>();

            _Repository.Setup(m => m.GetSingle(It.IsAny<Expression<Func<BaseEntity, bool>>>()))
                .Returns(entity).Verifiable();

            GenericService _Service = new GenericService(_Repository.Object);
            
            //When
            actual = _Service.GetItem(1);

            //Then
            _Repository.Verify();
            Assert.IsInstanceOf<DomainBaseEntity>(actual);
            Assert.IsNotNull(actual);
        }


    }
}
