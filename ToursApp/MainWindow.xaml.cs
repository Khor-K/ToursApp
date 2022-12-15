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
using System.IO;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ImportTours();
            MainFrame.Navigate(new HostelsPage());
            //MainFrame.Navigate(new ToursPage());
            Manager.MainFrame = MainFrame;
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\mrchu\Documents\Khoroshilov\Туры.txt");
            var images = Directory.GetFiles(@"C:\Users\mrchu\Documents\Khoroshilov\Туры фото");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');
                var tempTour = new Tour
                {
                    name = data[0].Replace("\"",""),
                    countryId = data[1].Replace(" ", ""),
                    ticketsCount = int.Parse(data[2]),
                    price = (int)decimal.Parse(data[3]),
                    isActual = (data[4] == "0") ? false : true
                };

                foreach (var tourType in data[5].Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = ToursEntities.GetContext().Type.ToList().FirstOrDefault(p => p.name == tourType);
                    if (currentType != null)
                        tempTour.Type.Add(currentType);
                }
                try
                {
                    tempTour.imagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ToursEntities.GetContext().Tour.Add(tempTour);
                ToursEntities.GetContext().SaveChanges();
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
