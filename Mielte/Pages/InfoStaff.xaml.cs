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
    /// Логика взаимодействия для InfoStaff.xaml
    /// </summary>

    public class PersonStaff
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Salary { get; set; }
        public string Position { get; set; }
        public string CarShowroom { get; set; }
    }

    public partial class InfoStaff : Page
    {

        public ObservableCollection<PersonStaff> StaffList { get; set; }

        private void FillingStaffList()
        {
            StaffList = new ObservableCollection<PersonStaff> { };

            static string searchGender(string gender)
            {
                return (gender == "М") ? "мужской" : "женский";
            }

            using (gavrilov_kpContext db = new gavrilov_kpContext())
            {
                // получаем объекты из бд и выводим
                var entries = db.Employees.Include(x => x.PositionNavigation).Include(x => x.CarDealershipNavigation).OrderBy(x => x.IdEmployees).ToList();
                foreach (Employees x in entries)
                {
                    StaffList.Add(new PersonStaff
                    {
                        Id = "ID: " + x.IdEmployees,
                        FullName = $"{x.Surname} {x.Name} {x.Patronymic}",
                        DateBirth = $"{x.DateBirth.ToShortDateString()}",
                        Address = $"Адрес: {x.Address}",
                        Gender = $"Пол: {searchGender(x.Gender)}",
                        Passport = $"Паспорт: {x.Passport}",
                        Phone = $"Телефон: {x.Phone}",
                        Salary = $"Оклад: {x.Salary.ToString("N0", new CultureInfo("en-us"))}.00 ₽",
                        Position = $"Должность: {x.PositionNavigation?.Title}",
                        CarShowroom = $"Автосалон: {x.CarDealershipNavigation?.Title}"
                    });
                }
            }

            StaffListBox.ItemsSource = StaffList;
        }

        public InfoStaff()
        {
            InitializeComponent();

            FillingStaffList();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание светлого цвета

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
    }
}
