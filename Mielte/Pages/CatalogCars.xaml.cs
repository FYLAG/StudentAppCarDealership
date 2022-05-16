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

namespace Mielte.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogCars.xaml
    /// </summary>
    public partial class CatalogCars : Page
    {

        public class CarCharacteristics
        {
            public string Id { get; set; }
            public string Image { get; set; }
            public string Date { get; set; }
            public string CharacteristicsEngine { get; set; }
            public string CharacteristicsChassis { get; set; }
            public string Colors { get; set; }
            public string Material { get; set; }
            public List<string> SourceOptions { get; set; }
        }

        string manufacturer = "";
        string model = "";
        string generation = "";

        public ObservableCollection<CarCharacteristics> CarCatalogList { get; set; }

        private void FillingCatalogList(string manufacturer, string model, string generation)
        {
            CarCatalogList = new ObservableCollection<CarCharacteristics> { };

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим на консоль
                var entries = db.Carcatalog
                    .Include(x => x.CarNavigation)
                    .Include(x => x.CarNavigation.ModelNavigation)
                    .Include(x => x.CarNavigation.ModelNavigation.ManufacturerNavigation)
                    .Include(x => x.EngineTypeNavigation)
                    .Include(x => x.CarDriveNavigation)
                    .Include(x => x.CarBoxNavigation)
                    .Include(x => x.BodyColorNavigation)
                    .Include(x => x.InteriorColorNavigation)
                    .Include(x => x.InteriorMaterialNavigation)
                    .Include(x => x.CarNavigation.BodyNavigation)
                    .OrderBy(x => x.IdCatalog).ToList();

                static CarCharacteristics AddInformation(Carcatalog x)
                {

                    List<string> options = new List<string>() { };

                    using (gavrilov_kpContext db = new gavrilov_kpContext())
                    {
                        // получаем объекты из бд и выводим на консоль
                        var indexOptions = db.Caroptions
                            .Include(o => o.IdCarNavigation)
                            .Include(o => o.IdOptionNavigation)
                            .OrderBy(o => o.IdOptionNavigation.Title).ToList();

                        foreach (Caroptions o in indexOptions)
                            if (x.IdCatalog == o.IdCarNavigation?.IdCatalog)
                                options.Add(o.IdOptionNavigation?.Title);
                    }

                        return new CarCharacteristics
                    {
                        Id = $"ID: {x.IdCatalog} \t {x.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title} {x.CarNavigation?.ModelNavigation?.Model} {x.CarNavigation?.Generation}",
                        Image = $@"{x.CarNavigation?.Image}",
                        Date = $"{x.DateManufacture.ToShortDateString()} \t {x.CarNavigation.BodyNavigation?.Title}",
                        CharacteristicsEngine = $"{x.EngineTypeNavigation?.Title} / {x.EngineVolume} / {x.EnginePower} л.с.",
                        CharacteristicsChassis = $"{x.CarDriveNavigation?.Title} / {x.CarBoxNavigation?.Title}",
                        Colors = $"{x.BodyColorNavigation?.Title} / {x.InteriorColorNavigation?.Title}",
                        Material = $"{x.InteriorMaterialNavigation?.Title}",
                        SourceOptions = options
                    };
                }

                foreach (Carcatalog x in entries)
                {
                    if (manufacturer == " " && model == " " && generation == " ")
                    {
                        CarCatalogList.Add(AddInformation(x));
                    } else {
                        if (x.CarNavigation?.ModelNavigation?.ManufacturerNavigation?.Title == manufacturer &&
                            x.CarNavigation?.ModelNavigation?.Model == model &&
                            x.CarNavigation?.Generation == generation)
                        {
                            CarCatalogList.Add(AddInformation(x));
                        }
                    }
                }
            }

            CarsListBox.ItemsSource = CarCatalogList;
        }

        public CatalogCars()
        {
            InitializeComponent();

            var DataBase = gavrilov_kpContext.GetContext();

            ComboBoxManufacturers.ItemsSource = DataBase.Carmanufacturers
                .OrderBy(x => x.IdManufacturer)
                .Select(x => x.Title).ToList();

            FillingCatalogList(" ", " ", " ");
        }

        private void ComboBoxManufacturers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var DataBase = gavrilov_kpContext.GetContext();

            ComboBoxModels.ItemsSource = null;
            ComboBoxGenerations.ItemsSource = null;
            manufacturer = ComboBoxManufacturers.SelectedItem.ToString();
            model = "";

            ComboBoxModels.ItemsSource = DataBase.Carmodels
                .Where(x => x.Manufacturer == (ComboBoxManufacturers.SelectedIndex+1))
                .OrderBy(x => x.IdModel)
                .Select(x => x.Model).ToList();
        }

        private void ComboBoxModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var DataBase = gavrilov_kpContext.GetContext();

            if (ComboBoxModels.ItemsSource != null)
            {
                ComboBoxGenerations.ItemsSource = null;
                model = ComboBoxModels.SelectedItem.ToString();
                generation = "";

                ComboBoxGenerations.ItemsSource = DataBase.Cargenerations
                    .Where(x => x.ModelNavigation.Model == ComboBoxModels.SelectedItem.ToString())
                    .OrderBy(x => x.IdGeneration)
                    .Select(x => x.Generation).ToList();
            }
        }

        private void ComboBoxGenerations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxGenerations.ItemsSource != null)
            {
                generation = ComboBoxGenerations.SelectedItem.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturer != "" && model != "" && generation != "")
            {
                CarsListBox.ItemsSource = null;

                FillingCatalogList(manufacturer, model, generation);

            } else {
                MessageBox.Show("Не все поля были выбранны!");
            }

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

        private void ButtonAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/AddModelCar.xaml", UriKind.Relative)); // переход на страницу добавления новой машины
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAdd.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAdd.Stroke = color0; // обводка блока чёрного цвета
        }
    }
}
