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
using System.Windows.Shapes;

namespace Mielte
{
    /// <summary>
    /// Логика взаимодействия для ViewLicense.xaml
    /// </summary>
    public partial class ViewLicense : Window
    {
        public ViewLicense(string linkImageLicense)
        {
            InitializeComponent();

            this.Resources["ImageLicenses"] = new BitmapImage(new Uri(linkImageLicense, UriKind.Relative));

        }
    }
}
