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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание светлого цвета

        private void ButtonOtherUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Authorization.xaml", UriKind.Relative)); // переход на страницу авторизации
        }
                
        private void ButtonOtherUser_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonOtherUser.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonOtherUser_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonOtherUser.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonSuppliers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/InfoSupplier.xaml", UriKind.Relative)); // переход на страницу информации о поставщиках
        }

        private void ButtonSuppliers_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSuppliers.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonSuppliers_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSuppliers.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonBuyers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/InfoBuyer.xaml", UriKind.Relative)); // переход на страницу информации о покупателях
        }

        private void ButtonBuyers_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBuyers.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBuyers_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBuyers.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonCatalogCars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CatalogCars.xaml", UriKind.Relative)); // переход на страницу каталога автомобилей
        }

        private void ButtonCatalogCars_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonCatalogCars.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonCatalogCars_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonCatalogCars.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonEmployees_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/InfoStaff.xaml", UriKind.Relative)); // переход на страницу сотрудников
        }

        private void ButtonEmployees_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonEmployees.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonEmployees_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonEmployees.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonSaleCars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/SaleCars.xaml", UriKind.Relative)); // переход на страницу продаваемых автомобилей
        }

        private void ButtonSaleCars_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonSaleCars.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonSaleCars_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonSaleCars.Stroke = color0; // обводка блока в чёрного цвета
        }

        private void ButtonAllTables_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/AllTables.xaml", UriKind.Relative)); // переход на страницу просмотра всех таблиц
        }

        private void ButtonAllTables_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAllTables.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonAllTables_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAllTables.Stroke = color0; // обводка блока в чёрного цвета
        }
    }
}
