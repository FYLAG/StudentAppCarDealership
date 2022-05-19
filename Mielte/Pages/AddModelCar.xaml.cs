using Mielte.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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
    /// Логика взаимодействия для AddModelCar.xaml
    /// </summary>
    public partial class AddModelCar : Page
    {

        gavrilov_kpContext DataBase = gavrilov_kpContext.GetContext();

        private void FillingComboBoxManufacturers()
        {
            ComboBoxListManufacturers.ItemsSource = DataBase.Carmanufacturers
                .OrderBy(x => x.IdManufacturer)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxTypeEngine()
        {
            ComboBoxListTypeEngine.ItemsSource = DataBase.Carenginestype
                .OrderBy(x => x.IdType)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxColorsBody()
        {
            ComboBoxListColorsBody.ItemsSource = DataBase.Colors
                .OrderBy(x => x.IdColor)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxColorsInterior()
        {
            ComboBoxListColorsInterior.ItemsSource = DataBase.Colors
                .OrderBy(x => x.IdColor)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxMaterialInterior()
        {
            ComboBoxListMaterialInterior.ItemsSource = DataBase.Interiormaterials
                .OrderBy(x => x.IdMaterial)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxCarBox()
        {
            ComboBoxListCarBox.ItemsSource = DataBase.Carbox
                .OrderBy(x => x.IdBox)
                .Select(x => x.Title).ToList();
        }

        private void FillingComboBoxCarDrive()
        {
            ComboBoxListCarDrive.ItemsSource = DataBase.Cardrive
                .OrderBy(x => x.IdDrive)
                .Select(x => x.Title).ToList();
        }

        private void FillingListBoxAllOptions()
        {
            ListBoxOptions.ItemsSource = DataBase.Alloptions
                .OrderBy(x => x.IdOption)
                .Select(x => x.Title).ToList();
        }

        public AddModelCar()
        {
            InitializeComponent();

            FillingComboBoxManufacturers();
            FillingComboBoxTypeEngine();
            FillingComboBoxColorsBody();
            FillingComboBoxColorsInterior();
            FillingComboBoxMaterialInterior();
            FillingComboBoxCarBox();
            FillingComboBoxCarDrive();
            FillingListBoxAllOptions();

        }

        private void ComboBoxListManufacturers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxListModels.ItemsSource = null;
            ComboBoxListGenerations.ItemsSource = null;

            ComboBoxListModels.ItemsSource = DataBase.Carmodels
                .Where(x => x.Manufacturer == (ComboBoxListManufacturers.SelectedIndex + 1))
                .OrderBy(x => x.IdModel)
                .Select(x => x.Model).ToList();
        }

        private void ComboBoxListModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboBoxListModels.ItemsSource != null)
            {
                ComboBoxListGenerations.ItemsSource = null;

                ComboBoxListGenerations.ItemsSource = DataBase.Cargenerations
                    .Where(x => x.ModelNavigation.Model == ComboBoxListModels.SelectedItem.ToString())
                    .OrderBy(x => x.IdGeneration)
                    .Select(x => x.Generation).ToList();
            }
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CatalogCars.xaml", UriKind.Relative)); // переход на страницу каталога
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
            if (ComboBoxListManufacturers.SelectedItem != null && ComboBoxListModels.SelectedItem != null && ComboBoxListGenerations.SelectedItem != null &&
                ComboBoxListTypeEngine.SelectedItem != null && TextBoxVolumeEngine.Text != "" && TextBoxPowerEngine.Text != "" &&
                ComboBoxListColorsBody.SelectedItem != null && ComboBoxListColorsInterior.SelectedItem != null && ComboBoxListMaterialInterior.SelectedItem != null &&
                ComboBoxListCarBox.SelectedItem != null && ComboBoxListCarDrive.SelectedItem != null)
            {
                try
                {
                    using (gavrilov_kpContext db = new gavrilov_kpContext())
                    {
                        MessageBox.Show(ComboBoxListGenerations.SelectedValue.ToString());
                        db.Carcatalog.Add(new Carcatalog
                        {                            
                            Car = Convert.ToInt16(db.Cargenerations
                                .Where(x => x.ModelNavigation.ManufacturerNavigation.Title == ComboBoxListManufacturers.SelectedValue.ToString()
                                    && x.ModelNavigation.Model == ComboBoxListModels.SelectedValue.ToString()
                                    && x.Generation == ComboBoxListGenerations.SelectedValue.ToString())
                                .Select(x => x.IdGeneration).ToList()[0]),
                            BodyColor = Convert.ToInt16(ComboBoxListColorsBody.SelectedIndex + 1),
                            InteriorColor = Convert.ToInt16(ComboBoxListColorsInterior.SelectedIndex + 1),
                            InteriorMaterial = Convert.ToInt16(ComboBoxListMaterialInterior.SelectedIndex + 1),
                            EngineType = Convert.ToInt16(ComboBoxListTypeEngine.SelectedIndex + 1),
                            EngineVolume = Convert.ToDecimal(TextBoxVolumeEngine.Text),
                            EnginePower = Convert.ToInt16(TextBoxPowerEngine.Text),
                            CarBox = Convert.ToInt16(ComboBoxListCarBox.SelectedIndex + 1),
                            CarDrive = Convert.ToInt16(ComboBoxListCarDrive.SelectedIndex + 1),
                            DateManufacture = (DateTime) DatePicherManufacture.SelectedDate
                        });

                        db.SaveChanges();

                        // Добавление опций
                        foreach (string item in ListBoxOptions.SelectedItems)
                        {
                            db.Caroptions.Add(new Caroptions { IdCar = db.Carcatalog.Count(), IdOption = ListBoxOptions.Items.IndexOf(item) + 1 });
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

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAdd.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAdd.Stroke = color0; // обводка блока в чёрного цвета
        }
    }
}
