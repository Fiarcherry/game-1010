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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PauseGameForm.xaml
    /// </summary>
    public partial class PauseGameForm : Window
    {
        public static Window a;
        public PauseGameForm()
        {
            InitializeComponent();
        }

        private void GoToGameButton_Click(object sender, RoutedEventArgs e)
        {
            //начать игру заного
            new GameForm().Show();
            a.Close();
            Close();
        }

        private void GoToMainButton_Click(object sender, RoutedEventArgs e)
        {
            //переход в окно главного меню
            new MainMenuForm().Show();
            a.Close();
            Close();
        }

        private void ReturnToGameButton_Click(object sender, RoutedEventArgs e)
        {
            //продолжить игру
            PauseGameForm.a.IsEnabled = true;
            Close();
        }
    }
}
