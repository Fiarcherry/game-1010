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
using System.Windows.Media.Animation;
using System.Xml.Serialization;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuForm : Window
    {
        //сериализация для рекордов
        RecordScore recordScore = new RecordScore();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(RecordScore));

        public MainMenuForm()
        {
            InitializeComponent();

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

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            //переход в окно игры
            new GameForm().Show();
            Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //выход из программы
            Close();
        }
    }
}
