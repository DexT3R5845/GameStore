﻿using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using GameStore.DAL.UnitsOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order = GameStore.DAL.Entities.Order;

namespace GameStore.DAL.Tests.UnitsOfWork
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestInitialize]
        public void Initialize()
        {
            UnitOfWork.IsSynchronized = true;
        }

        [TestMethod]
        public void Check_That_GameRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGameRepository repo = unitOfWork.GameRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GameRepository));
        }

        [TestMethod]
        public void Check_That_CommentRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<Comment> repo = unitOfWork.CommentRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<Comment>));
        }

        [TestMethod]
        public void Check_That_GenreRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<Genre> repo = unitOfWork.GenreRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<Genre>));
        }

        [TestMethod]
        public void Check_That_PlatformTypeRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<PlatformType> repo = unitOfWork.PlatformTypeRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<PlatformType>));
        }

        [TestMethod]
        public void Check_That_BasketRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<Basket> repo = unitOfWork.BasketRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<Basket>));
        }

        [TestMethod]
        public void Check_That_BasketItemRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<Order> repo = unitOfWork.OrderRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<Order>));
        }

        [TestMethod]
        public void Check_That_OrderRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<BasketItem> repo = unitOfWork.BasketItemRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<BasketItem>));
        }

        [TestMethod]
        public void Check_That_OrderItemRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<OrderItem> repo = unitOfWork.OrderItemRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<OrderItem>));
        }

        [TestMethod]
        public void Check_That_PublisherRepository_Property_Returns_Right_Repository()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();

            // Act
            IGenericRepository<Publisher> repo = unitOfWork.PublisherRepository;

            // Assert
            Assert.IsInstanceOfType(repo, typeof (GenericRepository<Publisher>));
        }
    }
}