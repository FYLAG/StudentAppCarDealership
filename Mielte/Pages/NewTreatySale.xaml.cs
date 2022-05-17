using Microsoft.EntityFrameworkCore;
using Mielte.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Логика взаимодействия для NewTreatySale.xaml
    /// </summary>
    public partial class NewTreatySale : Page
    {

        public class CarInfo
        {
            public int IdCatalog { get; set; }
            public string CarTitle { get; set; }
        }

        public class BuyersIfno//listBuyers
        {
            public int IdBuyer { get; set; }
            public string FullName { get; set; }
        }

        public class ManagersInfo//listManagers
        {
            public int IdManager { get; set; }
            public string FullName { get; set; }
        }

        public class ClassCars
        {
            public List<CarInfo> listCars { get; set; }
            public ClassCars()
            {
                listCars = new List<CarInfo> { };

                using (gavrilov_kpContext db = new gavrilov_kpContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var entries = db.Carsforsale
                        .Include(x => x.IdCarNavigation.CarNavigation.ModelNavigation.ManufacturerNavigation)
                        .Include(x => x.IdCarNavigation.CarNavigation.ModelNavigation)
                        .Include(x => x.IdCarNavigation.CarNavigation)
                        .Include(x => x.IdCarNavigation)
                        .OrderBy(x => x.IdCar).ToList();
                    foreach (Carsforsale x in entries)
                    {
                        listCars.Add(new CarInfo
                        {
                            IdCatalog = (int) x.IdCarNavigation?.IdCatalog,
                            CarTitle = $"ID: {x.IdCarNavigation?.IdCatalog}\t{x.IdCarNavigation?.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title} " +
                                    $"{x.IdCarNavigation?.CarNavigation?.ModelNavigation?.Model} " +
                                    $"{x.IdCarNavigation?.CarNavigation?.Generation}"
                        });
                    }
                }
            }
        }

        public class ClassBuyrs
        {
            public List<BuyersIfno> listBuyers { get; set; }

            public ClassBuyrs()
            {
                listBuyers = new List<BuyersIfno> { };

                using (gavrilov_kpContext db = new gavrilov_kpContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var entries = db.Buyers
                        .OrderBy(x => x.IdBuyer).ToList();
                    foreach (Buyers x in entries)
                    {
                        listBuyers.Add(new BuyersIfno
                        {
                            IdBuyer = (int) x.IdBuyer,
                            FullName = $"{x.Surname} {x.Name} {x.Patronymic}"
                        });
                    }
                }
            }
        }

        public class ClassManager
        {
            public List<ManagersInfo> listManagers { get; set; }

            public ClassManager()
            {
                listManagers = new List<ManagersInfo> { };

                using (gavrilov_kpContext db = new gavrilov_kpContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var entries = db.Employees
                        .Include(x => x.PositionNavigation)
                        .Where(x => x.PositionNavigation.IdPosition == 1)
                        .OrderBy(x => x.IdEmployees).ToList();
                    foreach (Employees x in entries)
                    {
                        listManagers.Add(new ManagersInfo
                        {
                            IdManager = (int) x.IdEmployees,
                            FullName = $"{x.Surname} {x.Name} {x.Patronymic}"
                        });
                    }
                }
            }
        }

        private void FillingAllOptions()
        {
            var DataBase = gavrilov_kpContext.GetContext();

            ListBoxServices.ItemsSource = DataBase.Cardealershipservices
                .OrderBy(x => x.IdServices)
                .Select(x => x.Title).ToList();
        }

        public NewTreatySale()
        {
            InitializeComponent();

            FillingAllOptions();

            ComboBoxIdAndTitleCar.DataContext = new ClassCars();
            ComboBoxBuyers.DataContext = new ClassBuyrs();
            ComboBoxManager.DataContext = new ClassManager();

            DatePickerSale.DisplayDateEnd = DateTime.Now;
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

            if (ComboBoxIdAndTitleCar.SelectedItem != null && ComboBoxBuyers.SelectedItem != null && ComboBoxManager.SelectedItem != null && TextBoxPrice.Text != "" && TextBoxVIN.Text != "") {

                try
                {

                    using (gavrilov_kpContext db = new gavrilov_kpContext())
                    {
                        db.Treatiessalecars.Add(new Treatiessalecars
                        {
                            Car = Convert.ToInt16(ComboBoxIdAndTitleCar.SelectedValue),
                            Buyer = Convert.ToInt16(ComboBoxBuyers.SelectedValue),
                            Manager = Convert.ToInt16(ComboBoxManager.SelectedValue),
                            DateSale = (DateTime)DatePickerSale.SelectedDate,
                            Vin = TextBoxVIN.Text,
                            Price = Convert.ToDecimal(TextBoxPrice.Text)
                        });

                        db.SaveChanges();

                        // Добавление
                        foreach (string item in ListBoxServices.SelectedItems)
                        {
                            MessageBox.Show($"{db.Treatiessalecars.Count()} - {ListBoxServices.Items.IndexOf(item) + 1}");
                            db.Contractservices.Add(new Contractservices { IdContract = db.Treatiessalecars.Count() + 1, IdServices = ListBoxServices.Items.IndexOf(item) + 1 });
                        }
                        db.SaveChanges();
                    }
                } catch (Exception) {
                    MessageBox.Show("Ошибка! Возможные причины: \n- Данные не верного формата;\n- Уникальность значений нарушена.");
                }

            } else {
                MessageBox.Show("Не все поля были заполнены!");
            }
        }

        private void ButtonApply_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonApply.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonApply_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonApply.Stroke = color0; // обводка блока чёрного цвета
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
