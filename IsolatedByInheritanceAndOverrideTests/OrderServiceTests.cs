using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace IsolatedByInheritanceAndOverride.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        /// <summary>
        /// Tests the synchronize book orders 3 orders only 2 book order.
        /// ProductName, Type, Price, CustomerName
        /// 商品1,        Book,  100, Kyo
        /// 商品2,        DVD,   200, Kyo
        /// 商品3,        Book,  300, Joey
        /// </summary>
        [TestMethod()]
        public void Test_SyncBookOrders_3_Orders_Only_2_book_order()
        {
            //Arrange
            var bookDao = Substitute.For<IBookDao>();
            var orderService = Substitute.For<OrderService>(bookDao);
            orderService.GetOrders().Returns(new List<Order>()
            {
                new Order()
                {
                    Type = "Book"
                },
                new Order()
                {
                    Type = "DVD"
                },
                new Order()
                {
                    Type = "Book"
                }
            });
            //Act
            orderService.SyncBookOrders();
            //Assert
            bookDao.Received(2).Insert(Arg.Any<Order>());
        }
    }
}