using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab3._2
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docAuto = XDocument.Load("CarDealer.xml");
            var autos = from car in docAuto.Descendants("машина")
                       select car;
            foreach (var car in autos)
            {
                AutoDataGrid.Items.Add(new
                {
                    Id = (string)car.Attribute("номер"),
                    Company = (string)car.Element("фирма"),
                    Model = (string)car.Element("модель"),
                    Body = (string)car.Element("кузов"),
                    Power = (string)car.Element("мощность"),
                    Price = (string)car.Element("цена"),
                    Responsible = (string)car.Element("ответственный_работник"),
                });
            }
        }
    }
}
