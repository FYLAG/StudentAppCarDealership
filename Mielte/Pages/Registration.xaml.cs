using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Mielte.Models;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {

        private const string salt = "Password";
        private const int IterationCount = 100000;
        private const int NumBytesRequested = 256 / 8;
        private const KeyDerivationPrf hMACSHA256 = KeyDerivationPrf.HMACSHA256;

        private static string HashPassword(string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password, salt: saltBytes, prf: hMACSHA256, iterationCount: IterationCount, numBytesRequested: NumBytesRequested));
        }

        public Registration()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush color238 = new SolidColorBrush(Color.FromRgb(238, 238, 238)); // создание светлого цвета
        Brush colorOrange = new SolidColorBrush(Color.FromRgb(255, 128, 0)); // создание оранжевого цвета

        private void ButtonBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Authorization.xaml", UriKind.Relative)); // переход на страницу авторизации
        }

        private void ButtonBack_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = colorOrange; // обводка блока оранжевого цвета
        }

        private void ButtonBack_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonBack.Stroke = color0; // обводка блока чёрного цвета
        }

        private void ButtonReg_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (TextBoxLogin.Text != "" && TextBoxEmail.Text != "" && PasswordBoxPass.Password != "" && PasswordBoxRetPass.Password != "")
            {
                if (PasswordBoxPass.Password == PasswordBoxRetPass.Password)
                {
                    var DataBase = gavrilov_kpContext.GetContext();

                    Userprogram user = new Userprogram() { Login = TextBoxLogin.Text, Email = TextBoxEmail.Text, Password = HashPassword(PasswordBoxPass.Password) };
                    try
                    {
                        DataBase.Userprogram.Add(user);
                        DataBase.SaveChanges();

                        App.Current.Properties["LoginOfProperty"] = TextBoxLogin.Text;
                        App.Current.Properties["RoleOfProperty"] = "User";

                        this.NavigationService.Navigate(new Uri("Pages/MainMenu.xaml", UriKind.Relative)); // Переход на страницу меню
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                    {
                        MessageBox.Show("Данный сотрудник уже зарегестрирован в базе");
                    }
                } else {
                    MessageBox.Show("Введённые вами пароли не совпадают!");
                }
            } else {
                MessageBox.Show("Не все поля были заполнены!");
            }
        }

        private void ButtonReg_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonLogin.Fill = color0; // закрашивание блока в чёрный цвет
            TextButtonLogin.Foreground = color238; // окрашивание текста в светлый цвет
        }

        private void ButtonReg_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonLogin.Fill = color238; // закрашивание блока в светлый цвет
            TextButtonLogin.Foreground = color0; // окрашивание текста в тёмный цвет
        }

        private void TextBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockLogin.Visibility = Visibility.Collapsed;
        }

        private void TextBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "")
                TextBlockLogin.Visibility = Visibility.Visible;
        }

        private void TextBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockEmail.Visibility = Visibility.Collapsed;
        }

        private void TextBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text == "")
                TextBlockEmail.Visibility = Visibility.Visible;
        }

        private void PasswordBoxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockPass.Visibility = Visibility.Collapsed;
        }

        private void PasswordBoxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPass.Password == "")
                TextBlockPass.Visibility = Visibility.Visible;
        }

        private void PasswordBoxRetPass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockRetPass.Visibility = Visibility.Collapsed;
        }

        private void PasswordBoxRetPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxRetPass.Password == "")
                TextBlockRetPass.Visibility = Visibility.Visible;
        }
    }
}
