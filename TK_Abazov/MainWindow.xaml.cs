using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TK_Abazov
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик переключения радиокнопок для смены интерфейса
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Проверка на инициализацию элементов, чтобы избежать ошибок при запуске
            if (Txt1 == null) return;

            // Скрываем все элементы перед выбором нужной фигуры
            Txt1.Visibility = Txt2.Visibility = Txt3.Visibility = Visibility.Collapsed;
            Lbl1.Visibility = Lbl2.Visibility = Lbl3.Visibility = Visibility.Collapsed;

            // Логика отображения полей для Прямоугольника
            if (RbRectangle.IsChecked == true)
            {
                Lbl1.Content = "1-я сторона:"; Lbl1.Visibility = Visibility.Visible; Txt1.Visibility = Visibility.Visible;
                Lbl2.Content = "2-я сторона:"; Lbl2.Visibility = Visibility.Visible; Txt2.Visibility = Visibility.Visible;
            }
            // Логика отображения полей для Круга
            else if (RbCircle.IsChecked == true)
            {
                Lbl1.Content = "Радиус:"; Lbl1.Visibility = Visibility.Visible; Txt1.Visibility = Visibility.Visible;
            }
            // Логика отображения полей для Треугольника
            else if (RbTriangle.IsChecked == true)
            {
                Lbl1.Visibility = Lbl2.Visibility = Lbl3.Visibility = Visibility.Visible;
                Txt1.Visibility = Txt2.Visibility = Txt3.Visibility = Visibility.Visible;
                Lbl1.Content = "1-я сторона:"; Lbl2.Content = "2-я сторона:"; Lbl3.Content = "3-я сторона:";
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Вычислить"
        /// </summary>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double res = 0;
                // Определение выбранной фигуры и вызов соответствующего метода из GeometryProvider
                if (RbRectangle.IsChecked == true)
                    res = GeometryProvider.CalculateRectangle(double.Parse(Txt1.Text), double.Parse(Txt2.Text));
                else if (RbCircle.IsChecked == true)
                    res = GeometryProvider.CalculateCircle(double.Parse(Txt1.Text));
                else if (RbTriangle.IsChecked == true)
                    res = GeometryProvider.CalculateTriangle(double.Parse(Txt1.Text), double.Parse(Txt2.Text), double.Parse(Txt3.Text));

                // Вывод результата с округлением
                TxtResult.Text = $"Площадь = {Math.Round(res, 2)}";
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке при некорректном вводе или нарушении правил геометрии
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}