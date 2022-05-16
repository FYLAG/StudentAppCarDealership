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

using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Mielte.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mielte.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoBuyer.xaml
    /// </summary>
    public partial class InfoBuyer : Page
    {

        public class PersonBuyer
        {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string DateBirth { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public string Passport { get; set; }
            public string Phone { get; set; }
            public string License { get; set; }
        }

        public ObservableCollection<PersonBuyer> BuyerList { get; set; }

        private void FillingStaffList()
        {
            BuyerList = new ObservableCollection<PersonBuyer> { };

            static string searchGender(string gender)
            {
                return (gender == "М") ? "мужской" : "женский";
            }

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим
                var entries = db.Buyers.OrderBy(x => x.IdBuyer).ToList();
                foreach (Buyers x in entries)
                {
                    BuyerList.Add(new PersonBuyer
                    {
                        Id = $"ID: {x.IdBuyer}",
                        FullName = $"{x.Surname} {x.Name} {x.Patronymic}",
                        DateBirth = $"{x.DateBirth.ToShortDateString()}",
                        Address = $"Адрес: {x.Address}",
                        Gender = $"Пол: {searchGender(x.Gender)}",
                        Passport = $"Паспорт: {x.Passport}",
                        Phone = $"Телефон: {x.Phone}",
                        License = $"{x.Certificate}"
                    });
                }
            }

            BuyerListBox.ItemsSource = BuyerList;
        }

        public InfoBuyer()
        {
            InitializeComponent();

            FillingStaffList();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            MessageBox.Show(e.Parameter.ToString());

            ViewLicense windowLicense = new ViewLicense(e.Parameter.ToString());
            windowLicense.Show();

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

        private void ButtonTreatySale_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TreatySale.xaml", UriKind.Relative)); // переход на страницу продаж
        }

        private void ButtonTreatySale_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonTreatySale.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonTreatySale_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonTreatySale.Stroke = color0; // обводка блока чёрного цвета
        }
    }
}
