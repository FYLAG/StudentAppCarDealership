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
    /// Логика взаимодействия для SaleCars.xaml
    /// </summary>
    public partial class SaleCars : Page
    {

        public class InfoCarSale
        {
            public string Title { get; set; }
            public string Image { get; set; }
            public string Price { get; set; }
        }

        public InfoCarSale obj { get; set; }

        public void updateDynamicResources()
        {
            this.Resources["Title"] = obj.Title;
            this.Resources["Image"] = new BitmapImage(new Uri(obj.Image, UriKind.Relative));
            this.Resources["Price"] = obj.Price;
        }

        public SaleCars()
        {
            InitializeComponent();

            obj = new InfoCarSale();

            obj.Title = "BMW M4 VII(G32) рестайлинг";
            obj.Image = @"\Pictures\Cars\BMW_M4.png";
            obj.Price = "10,000,000" + " ₽";

            updateDynamicResources();

        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

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

        private void ButtonCatalog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CatalogCars.xaml", UriKind.Relative)); // переход на страницу каталога автомобилей
        }

        private void ButtonCatalog_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCatalog.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonCatalog_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCatalog.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonBuy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/NewTreatySale.xaml", UriKind.Relative)); // переход на страницу покупки
        }

        private void ButtonBuy_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBuy.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBuy_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBuy.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonBefore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            obj.Title = "BMW M8 VII(G32) рестайлинг";
            obj.Image = @"\Pictures\Cars\BMW_M8.png";
            obj.Price = "24,000,000" + " ₽";

            updateDynamicResources();
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
            obj.Title = "BMW M4 VII(G32) рестайлинг";
            obj.Image = @"\Pictures\Cars\BMW_M4.png";
            obj.Price = "10,000,000" + " ₽";

            updateDynamicResources();
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
