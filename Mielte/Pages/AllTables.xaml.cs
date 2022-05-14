using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mielte.pages
{
    /// <summary>
    /// Логика взаимодействия для AllTables.xaml
    /// </summary>
    public partial class AllTables : Page
    {
        public AllTables()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание светлого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/MainMenu.xaml", UriKind.Relative)); // переход на страницу авторизации
        }

        private void ButtonBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonSave_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSave.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonSave_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSave.Stroke = color0; // обводка блока в чёрного цвета
        }
    }
}
