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
    /// Логика взаимодействия для TreatyBuy.xaml
    /// </summary>
    public partial class TreatyBuy : Page
    {

        public class InfoTreatyBuy
        {
            public string IdTreaty { get; set; }
            public string IdCar { get; set; }
            public string CarTitle { get; set; }
            public string Amount { get; set; }
            public string Supplier { get; set; }
            public string DateBuy { get; set; }
            public string Price { get; set; }
        }

        public ObservableCollection<InfoTreatyBuy> TreatyBuyList { get; set; }

        private void FillingTreatyBuyList()
        {
            TreatyBuyList = new ObservableCollection<InfoTreatyBuy> { };

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим на консоль
                var entries = db.Treatiesbuycars
                    .Include(x => x.CarNavigation.CarNavigation.ModelNavigation.ManufacturerNavigation)
                    .Include(x => x.CarNavigation.CarNavigation.ModelNavigation)
                    .Include(x => x.CarNavigation.CarNavigation)
                    .Include(x => x.SupplierNavigation)
                    .OrderBy(x => x.IdTreaty).ToList();
                foreach (Treatiesbuycars x in entries)
                {
                    TreatyBuyList.Add(new InfoTreatyBuy
                    {
                        IdTreaty = $"ID: {x.IdTreaty}",
                        IdCar = $"ID: {x.Car}",
                        CarTitle = $"{x.CarNavigation?.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title} " +
                                $"{x.CarNavigation?.CarNavigation?.ModelNavigation.Model} " +
                                $"{x.CarNavigation?.CarNavigation?.Generation}",
                        Amount = $"количество: {x.Amount}",
                        Supplier = $"поставщик: {x.SupplierNavigation?.Title}",
                        DateBuy = $"Дата заказа: {x.DateBuy.ToShortDateString()}",
                        Price = $"цена: {x.Price.ToString("N0", new CultureInfo("en-us"))}.00 ₽"
                    });
                }
            }
        }

        private void RefreshResources(string idTreaty, string idCarAndTitle, string amount, string buyer, string dateBuy, string price)
        {
            this.Resources["IdTreaty"] = idTreaty;
            this.Resources["IdCarAndTitle"] = idCarAndTitle;
            this.Resources["Amount"] = amount;
            this.Resources["DateBuy"] = new BitmapImage(new Uri(dateBuy, UriKind.Relative));
            this.Resources["Supplier"] = buyer;
            this.Resources["Price"] = price;
        }

        private void RefreshResourcesQuick()
        {
            RefreshResources(TreatyBuyList[i].IdTreaty, $"{TreatyBuyList[i].IdCar}\t{TreatyBuyList[i].CarTitle}",
                            TreatyBuyList[i].Amount, TreatyBuyList[i].Supplier, TreatyBuyList[i].DateBuy,
                            TreatyBuyList[i].Price);
        }

        int i = 0; // индекс первоначально увиденного договора

        public TreatyBuy()
        {
            InitializeComponent();

            FillingTreatyBuyList();

            RefreshResourcesQuick();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/InfoSupplier.xaml", UriKind.Relative)); // переход на страницу поставщиков
        }

        private void ButtonBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = color0; // обводка блока в чёрного цвета
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
                i = TreatyBuyList.Count - 1;
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
            if (i < TreatyBuyList.Count - 1)
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
