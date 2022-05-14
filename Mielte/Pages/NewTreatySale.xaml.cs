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
    /// Логика взаимодействия для NewTreatySale.xaml
    /// </summary>
    public partial class NewTreatySale : Page
    {
        public NewTreatySale()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/MainMenu.xaml", UriKind.Relative)); // переход на страницу меню
        }

        private void ButtonBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = color0; // обводка блока чёрного цвета
        }

        private void ButtonApply_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonApply_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonApply.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonApply_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonApply.Stroke = color0; // обводка блока чёрного цвета
        }
    }
}
