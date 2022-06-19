using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab3._2
{
    /// <summary>
    /// Логика взаимодействия для LaptopsPage.xaml
    /// </summary>
    public partial class LaptopsPage : Page
    {
        public LaptopsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docLaptops = XDocument.Load("laptops.xml");
            var laptops = from laptop in docLaptops.Descendants("Laptop")
                            select laptop;
            foreach (var laptop in laptops)
            {
                LaptopsDataGrid.Items.Add(new
                {
                    Id = (string)laptop.Attribute("Id"),
                    Company = (string)laptop.Element("Company"),
                    Model = (string)laptop.Element("Model"),
                    CPU = (string)laptop.Element("CPU"),
                    RAM = (string)laptop.Element("RAM"),
                });
            }
        }
    }
}
