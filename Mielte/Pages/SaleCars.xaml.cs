using Microsoft.EntityFrameworkCore;
using Mielte.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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

        public string GetLogin()
        {
            return App.Current.Properties["LoginOfProperty"].ToString();
        }

        public string GetRole()
        {
            return App.Current.Properties["RoleOfProperty"].ToString();
        }

        public class InfoCarSale
        {
            public string Title { get; set; }
            public string Image { get; set; }
            public string Price { get; set; }
        }

        public ObservableCollection<InfoCarSale> CarSaleList { get; set; }

        private void FillingSaleCarsList()
        {
            CarSaleList = new ObservableCollection<InfoCarSale> { };

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим на консоль
                var entries = db.Carsforsale
                    .Include(x => x.IdCarNavigation.CarNavigation.ModelNavigation.ManufacturerNavigation)
                    .Include(x => x.IdCarNavigation.CarNavigation)
                    .OrderBy(x => x.IdCar).ToList();
                foreach (Carsforsale x in entries)
                {
                    CarSaleList.Add(new InfoCarSale
                    {
                        Title = $"{x.IdCarNavigation?.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title} " +
                                $"{x.IdCarNavigation?.CarNavigation?.ModelNavigation.Model} " +
                                $"{x.IdCarNavigation?.CarNavigation?.Generation}",
                        Image = $@"{x.IdCarNavigation?.CarNavigation?.Image}",
                        Price = $"{x.Price.ToString("N0", new CultureInfo("en-us"))}.00 ₽"
                    });
                }
            }
        }

        private void RefreshResources(string title, string image, string price)
        {
            this.Resources["Title"] = title;
            this.Resources["Image"] = new BitmapImage(new Uri(image, UriKind.Relative));
            this.Resources["Price"] = price;
        }

        private void RefreshResourcesQuick()
        {
            RefreshResources(CarSaleList[i].Title, CarSaleList[i].Image, CarSaleList[i].Price);
        }

        int i = 0; // индекс первоначально увиденного автомобиля

        public SaleCars()
        {
            InitializeComponent();

            if (GetRole() != "Administrator" && GetRole() != "Manager")
            {
                ButtonBuy.Visibility = Visibility.Collapsed;
                LabelBuy.Visibility = Visibility.Collapsed;
            }

            FillingSaleCarsList();

            RefreshResourcesQuick();
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
            if (i > 0)
            {
                i--;
                RefreshResourcesQuick();
            }
            else
            {
                i = CarSaleList.Count - 1;
                RefreshResourcesQuick();
            }
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
            if (i < CarSaleList.Count - 1)
            {
                i++;
                RefreshResourcesQuick();
            }
            else
            {
                i = 0;
                RefreshResourcesQuick();
            }
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
