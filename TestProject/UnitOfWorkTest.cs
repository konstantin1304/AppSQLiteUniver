using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DB;
using DB.Common;
using DB.Entities;
using NUnit.Framework;
using SQLite;

namespace TestProject
{
    [TestFixture]
    public class UnitOfWorkTest
    {
        private UnitOfWork _unitOfWork;
        private SQLiteConnection _database;
        private string _dataPathMock;


        [SetUp]
        public void Setup()
        {
            _dataPathMock = "MyDataPath";
            _unitOfWork = new UnitOfWork(_dataPathMock);
        }

        [TearDown]
        public void Clear()
        {
            _dataPathMock = "";
            _unitOfWork = null;
        }

        [Test]
        public void CtorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _unitOfWork = new UnitOfWork(null);
            });
        }

        [Test]
        public void CtorCreateTest_Audience()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            //var database = (SQLiteConnection)typeof(UnitOfWork).GetField("database", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_unitOfWork);
            var expected = _unitOfWork.Audiences;
           // var audienceMock = new GenericRepository<Audience>(database);
            Assert.That(expected, Is.Not.Null);
        }


        [Test]
        public void CtorCreateTest_Departments()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Departments;
            Assert.That(expected, Is.Not.Null);
        }


        [Test]
        public void CtorCreateTest_AudLect()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.AudLects;
            Assert.That(expected, Is.Not.Null);
        }


        [Test]
        public void CtorCreateTest_Group()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Groups;
            Assert.That(expected, Is.Not.Null);
        }


        [Test]
        public void CtorCreateTest_Lections()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Lections;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Marks()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Marks;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Phones()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Phones;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Specialities()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Specialities;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Students()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Students;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Subjects()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Subjects;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_Teachers()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.Teachers;
            Assert.That(expected, Is.Not.Null);
        }

        [Test]
        public void CtorCreateTest_TeachSubjs()
        {
            _unitOfWork = new UnitOfWork(_dataPathMock);
            var expected = _unitOfWork.TeachSubjs;
            Assert.That(expected, Is.Not.Null);
        }
    }
    
}

