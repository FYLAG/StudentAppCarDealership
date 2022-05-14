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

namespace Mielte.Pages
{
    /// <summary>
    /// Логика взаимодействия для TreatySale.xaml
    /// </summary>
    public partial class TreatySale : Page
    {
        public TreatySale()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/InfoBuyer.xaml", UriKind.Relative)); // переход на страницу авторизации
        }

        private void ButtonBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonNewTreaty_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/NewTreatySale.xaml", UriKind.Relative)); // переход на страницу продажи
        }

        private void ButtonNewTreaty_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNewTreaty.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonNewTreaty_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNewTreaty.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonBefore_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonBefore_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBefore.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBefore_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBefore.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonAfter_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonAfter_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAfter.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonAfter_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAfter.Stroke = color0; // обводка блока в чёрного цвета
        }

    }
}
