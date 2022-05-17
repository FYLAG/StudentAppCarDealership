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
    /// Логика взаимодействия для TreatySale.xaml
    /// </summary>
    public partial class TreatySale : Page
    {
        public class InfoTreatySale
        {
            public string IdTreaty { get; set; }
            public string IdCar { get; set; }
            public string CarTitle { get; set; }
            public string Price { get; set; }
            public string VIN { get; set; }
            public string DateSale { get; set; }
            public string Buyer { get; set; }
            public string Manager { get; set; }
        }

        public ObservableCollection<InfoTreatySale> TreatySaleList { get; set; }

        private void FillingTreatySaleList()
        {
            TreatySaleList = new ObservableCollection<InfoTreatySale> { };

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим на консоль
                var entries = db.Treatiessalecars
                    .Include(x => x.CarNavigation.CarNavigation.ModelNavigation.ManufacturerNavigation)
                    .Include(x => x.CarNavigation.CarNavigation.ModelNavigation)
                    .Include(x => x.CarNavigation.CarNavigation)
                    .Include(x => x.BuyerNavigation)
                    .Include(x => x.ManagerNavigation)
                    .OrderBy(x => x.IdTreaty).ToList();
                foreach (Treatiessalecars x in entries)
                {
                    TreatySaleList.Add(new InfoTreatySale
                    {
                        IdTreaty = $"ID: {x.IdTreaty}",
                        IdCar = $"ID: {x.Car}",
                        CarTitle = $"{x.CarNavigation?.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title} " +
                                $"{x.CarNavigation?.CarNavigation?.ModelNavigation.Model} " +
                                $"{x.CarNavigation?.CarNavigation?.Generation}",
                        Price = $"цена: {x.Price.ToString("N0", new CultureInfo("en-us"))}.00 ₽",
                        VIN = $"VIN: {x.Vin}",
                        DateSale = $"Дата продажи: {x.DateSale.ToShortDateString()}",
                        Buyer = $"покупатель: {x.BuyerNavigation?.Surname} {x.BuyerNavigation?.Name} {x.BuyerNavigation?.Patronymic}",
                        Manager = $"менеджер: {x.ManagerNavigation?.Surname} {x.ManagerNavigation?.Name} {x.ManagerNavigation?.Patronymic}",
                    });
                }
            }
        }

        private void RefreshResources(string idTreaty, string idCarAndTitle, string price, string vin, string dateSale, string buyer, string manager)
        {
            this.Resources["IdTreaty"] = idTreaty;
            this.Resources["IdCarAndTitle"] = idCarAndTitle;
            this.Resources["Price"] = price;
            this.Resources["VIN"] = vin;
            this.Resources["DateSale"] = new BitmapImage(new Uri(dateSale, UriKind.Relative));
            this.Resources["Buyer"] = buyer;
            this.Resources["Manager"] = manager;
        }

        private void RefreshResourcesQuick()
        {
            RefreshResources(TreatySaleList[i].IdTreaty, $"{TreatySaleList[i].IdCar}\t{TreatySaleList[i].CarTitle}",
                            TreatySaleList[i].Price, TreatySaleList[i].VIN, TreatySaleList[i].DateSale,
                            TreatySaleList[i].Buyer, TreatySaleList[i].Manager);
        }

        int i = 0; // индекс первоначально увиденного договора

        public TreatySale()
        {
            InitializeComponent();

            FillingTreatySaleList();

            RefreshResourcesQuick();
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
            if (i > 0)
            {
                i--;
                RefreshResourcesQuick();
            }
            else
            {
                i = TreatySaleList.Count - 1;
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
            if (i < TreatySaleList.Count - 1)
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
