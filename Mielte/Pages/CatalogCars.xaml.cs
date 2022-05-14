using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для CatalogCars.xaml
    /// </summary>
    public partial class CatalogCars : Page
    {
        //kursgavrilovContext db;

        public CatalogCars()
        {
            InitializeComponent();

            //db = new kursgavrilovContext();

            //db.Покупатели.Load();

            //TextID = db.Покупатели.Include()
        }

        
        //using PhoneContext db = new PhoneContext();

    }
}
