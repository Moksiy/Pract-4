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

/*
 ПП4-1-2 Пользователь указывает размерность прямоугольной таблицы, после чего появляется соответствующее
 число TextBox’ов. После заполнения всех TextBox’ов и нажатия кнопки вычислить программа должна вычислить
 максимальное число среди минимальных элементов строк. Количество TextBox’ов не превышает 100 (10 × 10).
     */

namespace Pract4
{
    public class Data
    {
        public byte XMatrix { get; set; }
        public byte YMatrix { get; set; }
    }

    /// <summary>
    /// Логика (её нет) взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data = new Data();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (X.Text != "" && Y.Text != "")
            {
                data.XMatrix = Convert.ToByte(X.Text);
                data.YMatrix = Convert.ToByte(Y.Text);
                GenerateTextBoxes();
            }else { MessageBox.Show("Выберите размерность таблицы"); }
        }

        private void Y_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            /*Обработчик события выбора*/
        }

        private void X_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            /*Обработчик события выбора*/
        }

        private void GenerateTextBoxes()
        {
            Random rnd = new Random();
            Grid.Children.Clear();
            TextBox[,] elements = new TextBox[data.XMatrix, data.YMatrix];
            int xx = 35;
            int yy = 35;
            for (int i = 0; i < data.XMatrix; i++)
            {
                for (int j = 0; j < data.YMatrix; j++)
                {
                    TextBox box = new TextBox();
                    box.Height = 30;
                    box.Width = 30;
                    box.HorizontalAlignment = HorizontalAlignment.Left;
                    box.VerticalAlignment = VerticalAlignment.Top;
                    
                    box.Margin = new Thickness(200 + xx, 0 + yy, 0, 0);
                    box.Text = Convert.ToString(rnd.Next(0,99));
                    elements[i, j] = box;
                    Grid.Children.Add(box);
                    yy += 35;
                }
                xx += 35;
                yy = 35;
            }
        }

    }
}
