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

namespace Mielte.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        Brush color0 = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // создание чёрного цвета
        Brush color238 = new SolidColorBrush(Color.FromRgb(238, 238, 238)); // создание светлого цвета
        Brush color255 = new SolidColorBrush(Color.FromRgb(255, 255, 255)); // создание светлого цвета

        private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/MainMenu.xaml", UriKind.Relative)); // переход на страницу меню
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
    }
}
