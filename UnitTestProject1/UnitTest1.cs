using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TK_Abazov;

namespace UnitTestProject1

{
    [TestClass]
    public class GeometryTests
    {
        // ============================================================
        // ПОЛОЖИТЕЛЬНЫЕ ТЕСТЫ (POSITIVE) - 10 ТЕСТОВ
        // ============================================================ 

        [TestMethod]
        public void Rect_Standard_Success() // 1. Обычный прямоугольник
        {
            Assert.AreEqual(20, GeometryProvider.CalculateRectangle(4, 5));
        }

        [TestMethod]
        public void Rect_Square_Success() // 2. Квадрат (частный случай)
        {
            Assert.AreEqual(25, GeometryProvider.CalculateRectangle(5, 5));
        }

        [TestMethod]
        public void Rect_LargeValues_Success() // 3. Большие числа
        {
            Assert.AreEqual(1000000, GeometryProvider.CalculateRectangle(1000, 1000));
        }

        [TestMethod]
        public void Circle_Standard_Success() // 4. Обычный круг
        {
            double expected = Math.PI * 1;
            Assert.AreEqual(expected, GeometryProvider.CalculateCircle(1));
        }

        [TestMethod]
        public void Circle_FractionalRadius_Success() // 5. Дробный радиус
        {
            double expected = Math.PI * 0.25; // r=0.5
            Assert.AreEqual(expected, GeometryProvider.CalculateCircle(0.5));
        }

        [TestMethod]
        public void Tri_RightTriangle_Success() // 6. Прямоугольный треугольник (3,4,5)
        {
            Assert.AreEqual(6, GeometryProvider.CalculateTriangle(3, 4, 5));
        }

        [TestMethod]
        public void Tri_Equilateral_Success() // 7. Равносторонний треугольник
        {
            double res = GeometryProvider.CalculateTriangle(2, 2, 2);
            Assert.IsTrue(res > 1.73 && res < 1.74);
        }

        [TestMethod]
        public void Tri_Isosceles_Success() // 8. Равнобедренный треугольник
        {
            // Стороны 5, 5, 6. Высота будет 4. Площадь (6*4)/2 = 12
            Assert.AreEqual(12, GeometryProvider.CalculateTriangle(5, 5, 6));
        }

        [TestMethod]
        public void Tri_SmallValues_Success() // 9. Очень маленькие значения
        {
            double res = GeometryProvider.CalculateTriangle(0.1, 0.1, 0.1);
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void Rect_FloatingPoint_Success() // 10. Прямоугольник с плавающей точкой
        {
            Assert.AreEqual(7.5, GeometryProvider.CalculateRectangle(2.5, 3));
        }

        // ============================================================
        // ОТРИЦАТЕЛЬНЫЕ ТЕСТЫ (NEGATIVE) - 10 ТЕСТОВ
        // ============================================================

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rect_ZeroWidth_Fail() // 11. Ширина равна 0
        {
            GeometryProvider.CalculateRectangle(0, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rect_NegativeHeight_Fail() // 12. Отрицательная высота
        {
            GeometryProvider.CalculateRectangle(5, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Circle_ZeroRadius_Fail() // 13. Радиус равен 0
        {
            GeometryProvider.CalculateCircle(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Circle_NegativeRadius_Fail() // 14. Отрицательный радиус
        {
            GeometryProvider.CalculateCircle(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tri_ZeroSide_Fail() // 15. Одна сторона равна 0
        {
            GeometryProvider.CalculateTriangle(0, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tri_NegativeSide_Fail() // 16. Отрицательная сторона
        {
            GeometryProvider.CalculateTriangle(3, -4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tri_LineTriangle_Fail() // 17. Вырожденный треугольник (сумма двух сторон равна третьей)
        {
            GeometryProvider.CalculateTriangle(1, 2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tri_Impossible_Fail() // 18. Несуществующий треугольник (1, 1, 10)
        {
            GeometryProvider.CalculateTriangle(1, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tri_AllZero_Fail() // 19. Все стороны по нулям
        {
            GeometryProvider.CalculateTriangle(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rect_BothNegative_Fail() // 20. Обе стороны отрицательные
        {
            GeometryProvider.CalculateRectangle(-10, -5);
        }
    }
}