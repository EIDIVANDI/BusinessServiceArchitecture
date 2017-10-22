using System;
using NUnit.Framework;
using System.Data.Entity;
using BusinessServiceArchitecture_Repository;
using Moq;
using BusinessServiceArchitecture_Data;
using System.Collections.Generic;

namespace BusinessServiceArchitecture_Test.RepositoryLayer
{
    [TestFixture]
    public class GenericRepositoryTestClass
    {
        IEnumerable<BaseEntity> expectedList;

        [SetUp]
        public void GenerateTest()
        {
            expectedList = new List<BaseEntity>
            {
                 new BaseEntity{ Id = 1},
                 new BaseEntity{ Id = 2},
                 new BaseEntity{ Id = 3},
                 new BaseEntity{ Id = 4 }
            };
        }

        [Test]
        [Category("GenericRepository")]
        public void GENERIC_REPOSITORY_CREATION_TEST()
        {
            //Given 
            IGenericRepository actual;

            //When
            actual = new GenericRepository<BaseEntity, EntityContext>();

            //Then
            Assert.IsInstanceOf<IGenericRepository>(actual);
        }

        [Test]
        [Category("GenericRepository")]
        public void GENERIC_REPOSITORY_GETSINGLE_IDONE_TYPE_TEST()
        {
            //Given 
            BaseEntity actual = null;
            Mock<IGenericRepository<BaseEntity>> _Repository = new Mock<IGenericRepository<BaseEntity>>();


            _Repository.Setup(x => x.GetSingle(c => c.Id == 1))
                .Returns(new BaseEntity { Id = 1 });


            //When
            actual = _Repository.Object.GetSingle(e => e.Id == 1);

            //Then
            Assert.IsInstanceOf<BaseEntity>(actual);
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);

        }

        [Test]
        [Category("GenericRepository")]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void GENERIC_REPOSITORY_GETSINGLE_TYPE_TEST(int id)
        {
            //Given 
            BaseEntity actual = null;
            Mock<IGenericRepository<BaseEntity>> _Repository = new Mock<IGenericRepository<BaseEntity>>();


            _Repository.Setup(x => x.GetSingle(c => c.Id == id))
                .Returns(new BaseEntity() { Id = id });


            //When
            actual = _Repository.Object.GetSingle(e => e.Id == id);

            //Then
            Assert.IsNotNull(actual);
            Assert.AreEqual(id, actual.Id);
            Assert.IsInstanceOf<BaseEntity>(actual);

        }

        [Test]
        [Category("GenericRepository")]
        public void GENERIC_REPOSITORY_GETALL_TYPE_TEST()
        {
            //Given 
            IEnumerable<BaseEntity> actual = null;
            BaseEntity expectedObject = new BaseEntity { Id = 1 };
            Mock<IGenericRepository<BaseEntity>> _Repository = new Mock<IGenericRepository<BaseEntity>>();


            _Repository.Setup(x => x.GetAll())
                .Returns(expectedList);


            //When
            actual = _Repository.Object.GetAll();

            //Then
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<IEnumerable<BaseEntity>>(actual);
            Assert.AreSame(expectedList, actual);
        }



    }
}
