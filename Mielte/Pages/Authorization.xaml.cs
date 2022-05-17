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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {

        private const string salt = "Password";
        private const int IterationCount = 100000;
        private const int NumBytesRequested = 256 / 8;
        private const KeyDerivationPrf hMACSHA256 = KeyDerivationPrf.HMACSHA256;

        public static string HashPassword(string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password, salt: saltBytes, prf: hMACSHA256, iterationCount: IterationCount, numBytesRequested: NumBytesRequested));
        }

        public Authorization()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush color238 = new SolidColorBrush(Color.FromRgb(238, 238, 238)); // создание светлого цвета
        Brush color255 = new SolidColorBrush(Color.FromRgb(255, 255, 255)); // создание светлого цвета

        private void ButtonLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (TextBoxLogin_Authorization.Text != "" && PasswordBoxPass_Authorization.Password != "")
            {
                var DataBase = gavrilov_kpContext.GetContext();

                string login = TextBoxLogin_Authorization.Text.ToString();
                string pass = PasswordBoxPass_Authorization.Password.ToString();

                List<Userprogram> entries = DataBase.Userprogram.Where(x => x.Login == login && x.Password == HashPassword(pass)).ToList();

                if (entries.Count > 0)
                {

                    App.Current.Properties["LoginOfProperty"] = login;
                    App.Current.Properties["RoleOfProperty"] = DataBase.Userprogram.Where(x => x.Login == login).Select(x => x.Role).ToList()[0];

                    this.NavigationService.Navigate(new Uri("Pages/MainMenu.xaml", UriKind.Relative)); // переход на страницу меню

                } else {
                    MessageBox.Show("Введённый вами логин или пароль неверный!");
                }
            } else {
                MessageBox.Show("Не все поля были заполнены!");
            } 
        }

        private void ButtonLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonLogin.Fill = color0; // закрашивание блока в чёрный цвет
            TextButtonLogin.Foreground = color238; // окрашивание текста в светлый цвет
        }

        private void ButtonLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonLogin.Fill = color238; // закрашивание блока в светлый цвет
            TextButtonLogin.Foreground = color0; // окрашивание текста в чёрный цвет
        }

        private void BlockLinkReg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Registration.xaml", UriKind.Relative)); // переход на страницу регистрации
        }

        private void BlockLinkReg_MouseEnter(object sender, MouseEventArgs e)
        {
            BlockLinkReg.Fill = color0; // закрашивание блока в чёрный цвет
        }

        private void BlockLinkReg_MouseLeave(object sender, MouseEventArgs e)
        {
            BlockLinkReg.Fill = color255; // закрашивание блока в светлый цвет
        }

        private void TextBoxLogin_Authorization_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockLogin_Authorization.Visibility = Visibility.Collapsed;
        }

        private void TextBoxLogin_Authorization_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin_Authorization.Text == "")
                TextBlockLogin_Authorization.Visibility = Visibility.Visible;
        }

        private void PasswordBoxPass_Authorization_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBlockPass_Authorization.Visibility = Visibility.Collapsed;
        }

        private void PasswordBoxPass_Authorization_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPass_Authorization.Password == "")
                TextBlockPass_Authorization.Visibility = Visibility.Visible;
        }
    }
}
