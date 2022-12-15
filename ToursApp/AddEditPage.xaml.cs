using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();

        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursEntities.GetContext().Country.ToList();
        }

        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();
            ComboCountries.ItemsSource = ToursEntities.GetContext().Country.ToList();
            DataContext = _contentLoaded;
            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
                NameT.Text = selectedHotel.name;
                ComboCountries.SelectedValue = _currentHotel.Country;
                StarsT.Text = selectedHotel.countOfStars.ToString();
            }
            
        }

        private void BtnSave_Click_1(object sender, RoutedEventArgs e)
        {
            _currentHotel.Country = (Country)ComboCountries.SelectedValue;

            _currentHotel.countOfStars = int.Parse(StarsT.Text);
            _currentHotel.name = NameT.Text;

            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(_currentHotel.name))
                errors.AppendLine("Укажите название отеля ");
            if (_currentHotel.countOfStars < 1 || _currentHotel.countOfStars > 5)
                errors.AppendLine("Количество звёзд 1 - число от до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.id == null)
            {
                _currentHotel.id = ToursEntities.GetContext().Hotel.DefaultIfEmpty().Max(r => r == null ? 0 : r.id) + 1;
                ToursEntities.GetContext().Hotel.Add(_currentHotel);
            }
                

            try
            {
                ToursEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
