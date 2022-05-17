using Microsoft.EntityFrameworkCore;
using Mielte.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Mielte.pages
{
    /// <summary>
    /// Логика взаимодействия для AllTables.xaml
    /// </summary>
    public partial class AllTables : Page
    {

        public class TablesInfo//listBuyers
        {
            public string TableNameENG { get; set; }
            public string TableNameRUS { get; set; }
        }

        public class ClassTables
        {
            public List<TablesInfo> listTables { get; set; }

            public ClassTables()
            {
                listTables = new List<TablesInfo> {
                    new TablesInfo() { TableNameENG = "carGenerations", TableNameRUS = "поколения" },
                    new TablesInfo() { TableNameENG = "carDealerships", TableNameRUS = "автосалоны" },
                    new TablesInfo() { TableNameENG = "treatiesBuyCars", TableNameRUS = "договоры заказов автомобилей" },
                    new TablesInfo() { TableNameENG = "treatiesSaleCars", TableNameRUS = "договоры продаж автомобилей" },
                    new TablesInfo() { TableNameENG = "positions", TableNameRUS = "должности" },
                    new TablesInfo() { TableNameENG = "carCatalog", TableNameRUS = "каталог автомобилей" },
                    new TablesInfo() { TableNameENG = "carClass", TableNameRUS = "класс автомобиля" },
                    new TablesInfo() { TableNameENG = "carBox", TableNameRUS = "коробка" },
                    new TablesInfo() { TableNameENG = "carBody", TableNameRUS = "кузов" },
                    new TablesInfo() { TableNameENG = "interiorMaterials", TableNameRUS = "материалы салона" },
                    new TablesInfo() { TableNameENG = "carModels", TableNameRUS = "модели автомобиля" },
                    new TablesInfo() { TableNameENG = "allOptions", TableNameRUS = "опции" },
                    new TablesInfo() { TableNameENG = "carOptions", TableNameRUS = "опции автомобиля" },
                    new TablesInfo() { TableNameENG = "buyers", TableNameRUS = "покупатели" },
                    new TablesInfo() { TableNameENG = "suppliedBrands", TableNameRUS = "поставляемые марки" },
                    new TablesInfo() { TableNameENG = "suppliers", TableNameRUS = "поставщики" },
                    new TablesInfo() { TableNameENG = "carDrive", TableNameRUS = "привод" },
                    new TablesInfo() { TableNameENG = "carsForSale", TableNameRUS = "продаются" },
                    new TablesInfo() { TableNameENG = "carManufacturers", TableNameRUS = "производители" },
                    new TablesInfo() { TableNameENG = "employees", TableNameRUS = "сотрудники" },
                    new TablesInfo() { TableNameENG = "countries", TableNameRUS = "страны" },
                    new TablesInfo() { TableNameENG = "carEnginesType", TableNameRUS = "типы двигателей" },
                    new TablesInfo() { TableNameENG = "carDealershipServices", TableNameRUS = "услуги автосалона" },
                    new TablesInfo() { TableNameENG = "contractServices", TableNameRUS = "услуги по договору" },
                    new TablesInfo() { TableNameENG = "colors", TableNameRUS = "цвет" },
                    new TablesInfo() { TableNameENG = "carEnvironmentalClass", TableNameRUS = "экологический класс" },
                    new TablesInfo() { TableNameENG = "-", TableNameRUS = "-------------------" },
                    new TablesInfo() { TableNameENG = "popularColor", TableNameRUS = "хп:популярные цвета" },
                    new TablesInfo() { TableNameENG = "popularCar", TableNameRUS = "хп:популярные машины" },
                    new TablesInfo() { TableNameENG = "oldBuyer", TableNameRUS = "хп:старые покупатели" },
                    new TablesInfo() { TableNameENG = "salesManagers", TableNameRUS = "хп:продажи менеджеров" }
                };
            }
        }

        gavrilov_kpContext DataBase = gavrilov_kpContext.GetContext();

        public AllTables()
        {
            InitializeComponent();

            ComboBoxTables.DataContext = new ClassTables();

            DataGridTables.ItemsSource = DataBase.Carcatalog.ToList();
        }

        private void ComboBoxTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (ComboBoxTables.SelectedValue.ToString())
            {
                case "carGenerations":
                    DataGridTables.ItemsSource = DataBase.Cargenerations.ToList();
                    break;
                case "carDealerships":
                    DataGridTables.ItemsSource = DataBase.Cardealerships.ToList();
                    break;
                case "treatiesBuyCars":
                    DataGridTables.ItemsSource = DataBase.Treatiesbuycars.ToList();
                    break;
                case "treatiesSaleCars":
                    DataGridTables.ItemsSource = DataBase.Treatiessalecars.ToList();
                    break;
                case "positions":
                    DataGridTables.ItemsSource = DataBase.Positions.ToList();
                    break;
                case "carCatalog":
                    DataGridTables.ItemsSource = DataBase.Carcatalog.ToList();
                    break;
                case "carClass":
                    DataGridTables.ItemsSource = DataBase.Carclass.ToList();
                    break;
                case "carBox":
                    DataGridTables.ItemsSource = DataBase.Carbox.ToList();
                    break;
                case "carBody":
                    DataGridTables.ItemsSource = DataBase.Carbody.ToList();
                    break;
                case "interiorMaterials":
                    DataGridTables.ItemsSource = DataBase.Interiormaterials.ToList();
                    break;
                case "carModels":
                    DataGridTables.ItemsSource = DataBase.Carmodels.ToList();
                    break;
                case "allOptions":
                    DataGridTables.ItemsSource = DataBase.Alloptions.ToList();
                    break;
                case "carOptions":
                    DataGridTables.ItemsSource = DataBase.Caroptions.ToList();
                    break;
                case "buyers":
                    DataGridTables.ItemsSource = DataBase.Buyers.ToList();
                    break;
                case "suppliedBrands":
                    DataGridTables.ItemsSource = DataBase.Suppliedbrands.ToList();
                    break;
                case "suppliers":
                    DataGridTables.ItemsSource = DataBase.Suppliers.ToList();
                    break;
                case "carDrive":
                    DataGridTables.ItemsSource = DataBase.Cardrive.ToList();
                    break;
                case "carsForSale":
                    DataGridTables.ItemsSource = DataBase.Carsforsale.ToList();
                    break;
                case "carManufacturers":
                    DataGridTables.ItemsSource = DataBase.Carmanufacturers.ToList();
                    break;
                case "employees":
                    DataGridTables.ItemsSource = DataBase.Employees.ToList();
                    break;
                case "countries":
                    DataGridTables.ItemsSource = DataBase.Countries.ToList();
                    break;
                case "carEnginesType":
                    DataGridTables.ItemsSource = DataBase.Carenginestype.ToList();
                    break;
                case "carDealershipServices":
                    DataGridTables.ItemsSource = DataBase.Cardealershipservices.ToList();
                    break;
                case "contractServices":
                    DataGridTables.ItemsSource = DataBase.Contractservices.ToList();
                    break;
                case "colors":
                    DataGridTables.ItemsSource = DataBase.Colors.ToList();
                    break;
                case "carEnvironmentalClass":
                    DataGridTables.ItemsSource = DataBase.Carenvironmentalclass.ToList();
                    break;
                case "popularColor":
                    DataGridTables.ItemsSource = DataBase.Popularcolor.ToList();
                    break;
                case "popularCar":
                    DataGridTables.ItemsSource = DataBase.Popularcar.ToList();
                    break;
                case "oldBuyer":
                    DataGridTables.ItemsSource = DataBase.Oldbuyer.ToList();
                    break;
                case "salesManagers":
                    DataGridTables.ItemsSource = DataBase.Salesmanagers.ToList();
                    break;
            }
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
            DataBase.SaveChanges();

            MessageBox.Show("Сохранение прошло успешно!");
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

    internal class DbSet
    {
    }
}
