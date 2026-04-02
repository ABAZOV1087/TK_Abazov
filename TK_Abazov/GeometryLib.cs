using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Abazov
{
    /// <summary>
    /// Класс для выполнения геометрических расчетов площадей
    /// </summary>
    public static class GeometryProvider
    {
        /// <summary>
        /// Вычисляет площадь прямоугольника по двум сторонам
        /// </summary>
        /// <param name="a">Длина первой стороны</param>
        /// <param name="b">Длина второй стороны</param>
        /// <returns>Площадь прямоугольника</returns>
        public static double CalculateRectangle(double a, double b)
        {
            // Проверка на положительные значения сторон
            if (a <= 0 || b <= 0) throw new ArgumentException("Стороны должны быть больше нуля");
            return a * b;
        }

        /// <summary>
        /// Вычисляет площадь круга по его радиусу
        /// </summary>
        /// <param name="r">Радиус круга</param>
        /// <returns>Площадь круга</returns>
        public static double CalculateCircle(double r)
        {
            // Радиус не может быть отрицательным или нулевым
            if (r <= 0) throw new ArgumentException("Радиус должен быть больше нуля");
            return Math.PI * Math.Pow(r, 2);
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона
        /// </summary>
        /// <param name="a">Первая сторона</param>
        /// <param name="b">Вторая сторона</param>
        /// <param name="c">Третья сторона</param>
        /// <returns>Площадь треугольника</returns>
        public static double CalculateTriangle(double a, double b, double c)
        {
            // Проверка на положительные значения
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны должны быть больше нуля");

            // Проверка существования треугольника (сумма двух сторон больше третьей)
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Треугольник с такими сторонами не существует");

            // Вычисление полупериметра
            double p = (a + b + c) / 2;
            // Формула Герона
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}