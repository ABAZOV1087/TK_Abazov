using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TK_Abazov;

namespace TK_Abazov
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void Rectangle_ValidData_ReturnsArea()
        {
            Assert.AreEqual(20, GeometryProvider.CalculateRectangle(4, 5));
        }

        [TestMethod]
        public void Circle_ValidData_ReturnsArea()
        {
            double expected = Math.PI * 100;
            Assert.AreEqual(expected, GeometryProvider.CalculateCircle(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Triangle_InvalidSides_ThrowsException()
        {
            GeometryProvider.CalculateTriangle(1, 1, 10);
        }
    }
}