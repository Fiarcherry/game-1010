using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameForm : Window
    {
        /// <summary>
        /// Инициализация компонентов в GameForm окне
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
        }

        //массив квадратов с поля
        Rectangle[,] rectangles = new Rectangle[10,10];
        
        /// <summary>
        /// Генератор квадратов поля
        /// </summary>
        private void mainGridGenerator()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle mainFieldCell = new Rectangle();
                    mainFieldCell.Name = "r" + i + j;
                    mainFieldCell.Fill = Brushes.LightGray;
                    mainFieldCell.Width = 42;
                    mainFieldCell.Height = 42;
                    mainFieldCell.RadiusX = 10;
                    mainFieldCell.RadiusY = 10;
                    mainFieldCell.StrokeThickness = 0;
                    //помещение квадратов в Grid
                    mainFieldTableLayoutPanel.Children.Add(mainFieldCell);
                    mainFieldCell.SetValue(Grid.RowProperty, i * 2);
                    mainFieldCell.SetValue(Grid.ColumnProperty, j * 2);
                    //помещение квадратов в массив
                    rectangles[i, j] = mainFieldCell;
                }
            }
        }

        /// <summary>
        /// Определение фигуры и ее цвета
        /// </summary>
        /// <param name="randomFigure">Форма фигуры</param>
        public SolidColorBrush ColorsToFigures(ref int randomFigure)
        {   
            Color color = new Color();
            SolidColorBrush brush = new SolidColorBrush();
            //определитель цвета фигуры
            if ((randomFigure == 0) || (randomFigure == 5))
            {
                color = (Color)ColorConverter.ConvertFromString("#FFDB6555");
            }
            else if ((randomFigure == 1) || (randomFigure == 6))
            {
                color = (Color)ColorConverter.ConvertFromString("#FFE76A81");
            }
            else if ((randomFigure == 2) || (randomFigure == 7))
            {
                color = (Color)ColorConverter.ConvertFromString("#FFEF9647");
            }
            else if ((randomFigure == 3) || (randomFigure == 8))
            {
                color = (Color)ColorConverter.ConvertFromString("#FFFFC73C");
            }
            else if (randomFigure == 4)
            {
                color = (Color)ColorConverter.ConvertFromString("#FF788AC0");
            }
            else if ((randomFigure == 9) || (randomFigure == 10) || (randomFigure == 11) || (randomFigure == 12))
            {
                color = (Color)ColorConverter.ConvertFromString("#FF5DBFE1");
            }
            else if (randomFigure == 13)
            {
                color = (Color)ColorConverter.ConvertFromString("#FF4DD4AD");
            }
            else if (randomFigure == 14)
            {
                color = (Color)ColorConverter.ConvertFromString("#FF99DE55");
            }
            else if ((randomFigure == 15) || (randomFigure == 16) || (randomFigure == 17) || (randomFigure == 18))
            {
                color = (Color)ColorConverter.ConvertFromString("#FF57CB84");
            }
            brush = new SolidColorBrush(color);
            return brush;
        }

        //массив для двумерного массива с 0 и 1, из которых получается фигура
        int[][,] figures = new int[19][,];
        //запоминание формы и типа 3-х фигур
        int[] figureField = new int[3];
        SolidColorBrush[] figureBrush = new SolidColorBrush[3];

        /// <summary>
        /// Генератор 3-х фигур
        /// </summary>
        private void SecondFieldRandom()
        {
            //объявление всех фигур
            int[,] figure1 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {1,1,1,1,1},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure2 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {1,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure3 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure4 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure5 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure6 = {
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0}
            };
            int[,] figure7 = {
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
            };
            int[,] figure8 = {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
            };
            int[,] figure9 = {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure10 = {
                {0,0,0,0,0},
                {0,0,0,1,0},
                {0,0,0,1,0},
                {0,1,1,1,0},
                {0,0,0,0,0}
            };
            int[,] figure11 = {
                {0,0,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,1,1,1,0},
                {0,0,0,0,0}
            };
            int[,] figure12 = {
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,0,0,1,0},
                {0,0,0,1,0},
                {0,0,0,0,0}
            };
            int[,] figure13 = {
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure14 = {
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,1,1,1,0},
                {0,1,1,1,0},
                {0,0,0,0,0}
            };
            int[,] figure15 = {
                {0,0,0,0,0},
                {0,1,1,0,0},
                {0,1,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure16 = {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,1,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure17 = {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            };
            int[,] figure18 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
            };
            int[,] figure19 = {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
            };
            //перенос всех фигур в массив
            figures[0] = figure1;
            figures[1] = figure2;
            figures[2] = figure3;
            figures[3] = figure4;
            figures[4] = figure5;
            figures[5] = figure6;
            figures[6] = figure7;
            figures[7] = figure8;
            figures[8] = figure9;
            figures[9] = figure10;
            figures[10] = figure11;
            figures[11] = figure12;
            figures[12] = figure13;
            figures[13] = figure14;
            figures[14] = figure15;
            figures[15] = figure16;
            figures[16] = figure17;
            figures[17] = figure18;
            figures[18] = figure19;

            //переменная для рандома
            Random random = new Random();
            //переменная для записи фигуры в определенный столбец
            int columnValue = 1;
            for (int i = 0; i < 3; i++)
            {
                //цвет фигуры
                SolidColorBrush brush = new SolidColorBrush();
                //форма фигуры
                int randomFigure = 0;
                //рандомазер фигуры
                randomFigure = random.Next(19);
                //определитель ее цвета
                brush = ColorsToFigures(ref randomFigure);
                figureField[i] = randomFigure;
                figureBrush[i] = brush;
                GridLengthConverter converter = new GridLengthConverter();
                //прорисовка поля для фигуры
                Grid secondFieldFigure = new Grid();
                secondFieldFigure.Name = "SecondFieldFigure" + (i + 1);
                secondFieldTableLayoutPanel.Children.Add(secondFieldFigure);
                secondFieldFigure.SetValue(Grid.ColumnProperty, columnValue);
                columnValue += 2;
                secondFieldFigure.MouseDown += Button_MouseDown;
                for (int j = 0; j < 9; j++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    rowDefinition.Name = "rowDefinition" + j;
                    columnDefinition.Name = "columnDefinition" + j;
                    if (j % 2 == 0)
                    {
                        rowDefinition.Height = (GridLength)converter.ConvertFrom(35);
                        columnDefinition.Width = (GridLength)converter.ConvertFrom(35);
                    }
                    else
                    {
                        rowDefinition.Height = (GridLength)converter.ConvertFrom(1);
                        columnDefinition.Width = (GridLength)converter.ConvertFrom(1);
                    }
                    secondFieldFigure.RowDefinitions.Add(rowDefinition);
                    secondFieldFigure.ColumnDefinitions.Add(columnDefinition);
                }
                //прорисовка фигуры
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (figures[randomFigure][j, k] == 1)
                        {
                            Rectangle secondFieldCell = new Rectangle();
                            secondFieldCell.Name = "sf" + (i + 1) + "r" + j + k;
                            secondFieldCell.Fill = brush;
                            secondFieldCell.Width = 35;
                            secondFieldCell.Height = 35;
                            secondFieldCell.RadiusX = 8;
                            secondFieldCell.RadiusY = 8;
                            secondFieldCell.StrokeThickness = 0;
                            secondFieldFigure.Children.Add(secondFieldCell);
                            secondFieldCell.SetValue(Grid.RowProperty, j * 2);
                            secondFieldCell.SetValue(Grid.ColumnProperty, k * 2);
                        }
                    }
                }
            }
        }

        //сериализация для рекордов
        RecordScore recordScore = new RecordScore();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(RecordScore));

        /// <summary>
        /// Загрузка окна игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //генератор поля
            mainGridGenerator();
            //рандомайзер 3х фигур во втором поле
            SecondFieldRandom();
            //вывод рекорда
            using (FileStream fs = new FileStream("record.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    recordScore = (RecordScore)xmlSerializer.Deserialize(fs);
                }
                catch
                {
                    recordScore.Record = 0;
                }
            }
            recordScoreLabel.Content = recordScore.Record;
        }

        /// <summary>
        /// Нажатие на кнопку паузы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            //переход в окно паузы
            PauseGameForm.a = this;
            new PauseGameForm().Show();
            PauseGameForm.a.IsEnabled = false;
        }
        
        //изначальная позиция фигуры (VCStart, HCStart) и координаты курсора (x, y)
        private double VCStart = 0, HCStart = 0, x = 0, y = 0;
        //перетаскиваемая фигура
        Grid activeFigure;
        //цвет выбранной фигуры
        SolidColorBrush activeFigureBrush;
        //все данные о перетаскиваемой фигуре(i, j, isCapture всех квадратов)
        int[,] ijOfFigure;
        //перетаскиваемые квадраты
        Rectangle[] arr;
        //взята фигура (false) или нет (true)
        bool t = false;
        
        /// <summary>
        /// Перемещение мыши по окну игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            //срабатывает только при условии, что есть перетаскиваемая фигура
            if (t)
            {
                //положение курсора относительно начала перетаскивания
                x = e.GetPosition(this).X - HCStart;
                y = e.GetPosition(this).Y - VCStart;
                //положение курсора относительно формы
                activeFigure.Margin = new Thickness(x, y, -x, -y);
            }
        }
        
        /// <summary>
        /// Захват и отрисовка фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!t)
            {
                activeFigure = (Grid)sender;
                VCStart = e.GetPosition(this).Y;
                HCStart = e.GetPosition(this).X;
                t = true;
                //определение цвета фигуры
                if (activeFigure.Name == "SecondFieldFigure1")
                {
                    activeFigureBrush = figureBrush[0];
                }
                else if (activeFigure.Name == "SecondFieldFigure2")
                {
                    activeFigureBrush = figureBrush[1];
                }
                else
                {
                    activeFigureBrush = figureBrush[2];
                }
                //i, j квадратов фигуры
                arr = new Rectangle[activeFigure.Children.Count];
                activeFigure.Children.CopyTo(arr, 0);
                ijOfFigure = new int[3, activeFigure.Children.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    ijOfFigure[1, i] = Convert.ToInt32(arr[i].Name[4].ToString());
                    ijOfFigure[2, i] = Convert.ToInt32(arr[i].Name[5].ToString());
                    //i, j квадрата с курсором
                    if (arr[i].IsMouseOver)
                    {
                        ijOfFigure[0, i] = 1;
                    }
                    else
                    {
                        ijOfFigure[0, i] = 0;
                    }
                }
            }
            else
            {
                //координаты курсора
                x = e.GetPosition(this).X;
                y = e.GetPosition(this).Y;
                //координаты начала и конца одного из квадратов поля
                int wStart = 75;
                int hStart = 75;
                int wEnd = 117;
                int hEnd = 117;
                bool test = false;
                Rectangle rect = new Rectangle();
                //возвращение фигуры на место
                if ((x < 75) || (y < 75) || (x > 513) || (y > 513))
                {   
                    activeFigure.Margin = new Thickness(0,0,0,0);
                    activeFigure = null;
                    t = false;
                    test = true;
                }
                //определение местоположения фигуры при выставлении ее на поле
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if((x > wStart) && (x < wEnd) && (y > hStart) && (y < hEnd))
                        {
                            //закрашивание квадрата на поле
                            rect = rectangles[i, j];
                        }
                        wStart += 44;
                        wEnd += 44;
                    }
                    hStart += 44;
                    hEnd += 44;
                    wStart = 75;
                    wEnd = 117;
                }
                if (rect.Name == "")
                {
                    
                }
                else
                {
                    //i, j квадрата с курсором на поле
                    int iFigure = Convert.ToInt32(rect.Name[1].ToString());
                    int jFigure = Convert.ToInt32(rect.Name[2].ToString());
                    int iDiff = 0;
                    int jDiff = 0;
                    //начало отрисовки с квадрата, на котором курсор
                    for (int i = 0; i < activeFigure.Children.Count; i++)
                    {
                        if (ijOfFigure[0, i] == 1)
                        {
                            iDiff = iFigure - ijOfFigure[1, i];
                            jDiff = jFigure - ijOfFigure[2, i];
                        }
                    }
                    //ограничения на установку фигуры
                    int iTest = 0;
                    int jTest = 0;
                    for (int i = 0; i < activeFigure.Children.Count; i++)
                    {
                        iTest = ijOfFigure[1, i];
                        iTest += iDiff;
                        jTest = ijOfFigure[2, i];
                        jTest += jDiff;
                        //тест на границы поля
                        if ((iTest < 0) || (iTest > 9) || (jTest < 0) || (jTest > 9))
                        {
                            test = true;
                        }
                        
                        //тест на другие фигуры под данной
                        if (!test)
                        {
                            if (rectangles[iTest, jTest].Fill != Brushes.LightGray)
                            {
                                test = true;
                            }
                        }
                    }
                    if (!test)
                    {
                        //отрисовка целой фигуры
                        for (int i = 0; i < activeFigure.Children.Count; i++)
                        {
                            ijOfFigure[1, i] += iDiff;
                            ijOfFigure[2, i] += jDiff;
                            rectangles[ijOfFigure[1, i], ijOfFigure[2, i]].Fill = activeFigureBrush;
                        }
                        //добавление очков (поставлена фигура)
                        try
                        {
                            scoreLabel.Content = Convert.ToInt32(scoreLabel.Content) + activeFigure.Children.Count;
                        }
                        catch
                        {
                            scoreLabel.Content = 0;
                            recordScoreLabel.Content = 0;
                            recordScore.Record = 0;
                        }
                        if (Convert.ToInt32(scoreLabel.Content) > Convert.ToInt32(recordScoreLabel.Content))
                        {
                            recordScoreLabel.Content = Convert.ToInt32(scoreLabel.Content);
                            //сохранение рекорда
                            recordScore.Record = Convert.ToInt32(recordScoreLabel.Content);
                            using (FileStream fs = new FileStream("record.xml", FileMode.Create))
                            {
                                xmlSerializer.Serialize(fs, recordScore);
                            }
                        }
                        //удаление перетаскиваемой фигуры
                        Grid par = (Grid)activeFigure.Parent;
                        par.Children.Remove(activeFigure);
                        t = false;
                        if (par.Children.Count == 0)
                        {
                            SecondFieldRandom();
                        }
                        //начисление очков за линию
                        Scores();
                    }
                }
            }
        }

        /// <summary>
        /// Подсчет очков за собранную линию
        /// </summary>
        private void Scores()
        {
            int[,] ijLine = {
                {1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1}
            };
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (rectangles[i, j].Fill == Brushes.LightGray)
                    {
                        ijLine[0, i] = 0;
                        ijLine[1, j] = 0;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (ijLine[0, i] == 1)
                {
                    try
                    {
                        scoreLabel.Content = Convert.ToInt32(scoreLabel.Content) + 10;
                    }
                    catch
                    {
                        scoreLabel.Content = 0;
                        recordScoreLabel.Content = 0;
                        recordScore.Record = 0;
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        rectangles[i, j].Fill = Brushes.LightGray;
                    }
                }
            }
            for (int j = 0; j < 10; j++)
            {
                if (ijLine[1, j] == 1)
                {
                    try
                    {
                        scoreLabel.Content = Convert.ToInt32(scoreLabel.Content) + 10;
                    }
                    catch
                    {
                        scoreLabel.Content = 0;
                        recordScoreLabel.Content = 0;
                        recordScore.Record = 0;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        rectangles[i, j].Fill = Brushes.LightGray;
                    }
                }
            }
            if (Convert.ToInt32(scoreLabel.Content) > Convert.ToInt32(recordScoreLabel.Content))
            {
                recordScoreLabel.Content = Convert.ToInt32(scoreLabel.Content);
                //сохранение рекорда
                recordScore.Record = Convert.ToInt32(recordScoreLabel.Content);
                using (FileStream fs = new FileStream("record.xml", FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, recordScore);
                }
            }
        }
    }
}
